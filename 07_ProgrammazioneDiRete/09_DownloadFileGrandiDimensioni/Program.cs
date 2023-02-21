using SettingProxy;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _09_DownloadFileGrandiDimensioni
{
    public class Program
    {
        public static HttpClient client;
        static long bytesRecieved = 0;
        static long? totalBytes;
        static int left;
        static int top;

        //static async Task WriteBinaryAsync(string filePathDestination, Stream inputStream, int writeBufferSize = 4096)
        //{
        //    using FileStream outputStream = new(filePathDestination, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: writeBufferSize, useAsync: true);
        //    await inputStream.CopyToAsync(outputStream);
        //}

        static async Task WriteBinaryAsyncWithProgress(string filePathDestination, Stream inputStream)
        {
            //Scrive un file nel percorso destinazione a partire da uno stream di input, con la percentuale di progresso.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.CursorVisible = false;
            }
            using FileStream outputStream = new(filePathDestination,
            FileMode.Create, FileAccess.Write, FileShare.None,
            bufferSize: 4096, useAsync: true);
            byte[] buffer = new byte[0x100000];//circa 1MB di buffer
            int numRead;
            while ((numRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                await outputStream.WriteAsync(buffer, 0, numRead);
                bytesRecieved += numRead;
                double? percentComplete = (double)bytesRecieved / totalBytes;
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"download al {percentComplete * 100:F2}%");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                Console.CursorVisible = true;
            }
        }

        static string GetFileNameFromUrl(string url)
        {
            Uri SomeBaseUri = new("http://canbeanything");
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri))
                uri = new Uri(SomeBaseUri, url);
            return Path.GetFileName(uri.LocalPath);
        }

        static async Task Main(string[] args)
        {
            const string url = "https://download.visualstudio.microsoft.com/download/pr/639f7cfa-84f8-48e8-b6c9-82634314e28f/8eb04e1b5f34df0c840c1bffa363c101/dotnet-sdk-3.1.100-win-x64.exe";
            MyProxy.HttpClientProxySetup(out client);
            try
            {
                HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var sw = new Stopwatch();
                sw.Start();
                Console.WriteLine("Salvataggio su file in corso...");
                //ottengo il nome del file dall'url
                string fileName = GetFileNameFromUrl(url);
                //definisco il path complessivo del file
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar + fileName;
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    //copio in modalità async il file 
                    //await WriteBinaryAsync(path, streamToReadFrom);
                    totalBytes = response.Content.Headers.ContentLength;
                    left = Console.CursorLeft;
                    top = Console.CursorTop;
                    await WriteBinaryAsyncWithProgress(path, streamToReadFrom);
                }
                long elapsedMs = sw.ElapsedMilliseconds;
                Console.WriteLine($"Salvataggio terminato...in {elapsedMs} ms");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Generata eccezione con messaggio: "+e.Message);
            }
        }
    }
}