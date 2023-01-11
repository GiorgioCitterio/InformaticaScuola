namespace _06_Preferences;

public partial class PagePreferences : ContentPage
{
    string cacheDir;
    string targetFile;
    public PagePreferences()
    {
        InitializeComponent();
        cacheDir = FileSystem.Current.CacheDirectory;
        Path.Text = cacheDir;
        targetFile = System.IO.Path.Combine(cacheDir, "File.txt");
    }

    private void Salva(object sender, EventArgs e)
    {
        string dati = Preferences.Default.Get("Cognome", "Default");
        dati += Cognome.Text;
        Preferences.Default.Set("Cognome", dati);
        Cognome.Text = string.Empty;

    }

    private void Carica(object sender, EventArgs e)
    {
        lblCognome.Text = Preferences.Default.Get("Cognome", "Default");
    }

    private void Reset(object sender, EventArgs e)
    {
        Preferences.Default.Remove("Cognome");
    }

    private async void CaricaCache(object sender, EventArgs e)
    {
        using FileStream inputStream=File.OpenRead(targetFile);
        using StreamReader streamReader=new StreamReader(inputStream);
        lblCognome.Text=await streamReader.ReadToEndAsync();
    }

    private async void SalvaCache(object sender, EventArgs e)
    {
        using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new StreamWriter(outputStream);
        await streamWriter.WriteAsync(Cognome.Text);
        Cognome.Text = string.Empty;
    }
}