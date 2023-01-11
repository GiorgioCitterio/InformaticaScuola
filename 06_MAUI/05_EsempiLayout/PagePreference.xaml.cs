namespace _05_EsempiLayout;

public partial class PagePreference : ContentPage
{
    string cacheDir;
    string targetFile;
	public PagePreference()
	{
		InitializeComponent();
        cacheDir = FileSystem.Current.CacheDirectory;
        Path.Text = "Percorso cache = "+cacheDir;
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
    private async void SalvaCache(object sender, EventArgs e)
    {
        using FileStream outputStream = File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new StreamWriter(outputStream);
        await streamWriter.WriteAsync(Cognome.Text);
        Cognome.Text = string.Empty;
    }
    private async void CaricaCache(object sender, EventArgs e)
    {
        using FileStream inputStream = File.OpenRead(targetFile);
        using StreamReader streamReader = new StreamReader(inputStream);
        lblCognome.Text = await streamReader.ReadToEndAsync();
    }
    private async void LeggiBoundle(object sender, EventArgs e)
    {
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("Prova.txt");
        using StreamReader streamReader = new StreamReader(fileStream);
        lblCognome.Text = await streamReader.ReadToEndAsync();
    }
}