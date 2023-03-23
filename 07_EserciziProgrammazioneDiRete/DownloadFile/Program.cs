namespace DownloadFile
{
    public class Program
    {
        static HttpClient client = new HttpClient();
        static async Task<int> DowloadFile()
        {
            byte[] array = await client.GetByteArrayAsync(client.BaseAddress);
            return array.Length;
        }
        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf");
            int var = await DowloadFile();
            Console.WriteLine(var);
        }
    }
}