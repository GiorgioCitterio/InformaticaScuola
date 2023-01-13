namespace _00_MemoryGiorgioCitterio;

public partial class Vittoria : ContentPage
{
    public static List<Dati> listaDati = new List<Dati>(5);
    public Dati datoCorrente= new Dati();
    public Vittoria()
	{
		InitializeComponent();
        datoCorrente.data = Facile.Dati.data;
        datoCorrente.mosseImpiegate = Facile.Dati.mosseImpiegate;
        datoCorrente.tempoImpiegato = Facile.Dati.tempoImpiegato;
        datoCorrente.tema = Facile.Dati.tema;
        listaDati.Add(datoCorrente);
        for (int i = 0; i < listaDati.Count; i++)
        {
            switch (i)
            {
                case 0: lbl1.Text += ("Tema: " + listaDati[i].tema + " - " + " Data: " + listaDati[i].data.ToString() + " - " + " Mosse: " + listaDati[i].mosseImpiegate.ToString() + " - " + " Tempo impiegato: " + listaDati[i].tempoImpiegato.ToString());
                    break;
                case 1: lbl2.Text += ("Tema: " + listaDati[i].tema + " - " + " Data: " + listaDati[i].data.ToString() + " - " + " Mosse: " + listaDati[i].mosseImpiegate.ToString() + " - " + " Tempo impiegato: " + listaDati[i].tempoImpiegato.ToString());
                    break;
                case 2: lbl3.Text += ("Tema: " + listaDati[i].tema + " - " + " Data: " + listaDati[i].data.ToString() + " - " + " Mosse: " + listaDati[i].mosseImpiegate.ToString() + " - " + " Tempo impiegato: " + listaDati[i].tempoImpiegato.ToString());
                    break;
                case 3: lbl4.Text += ("Tema: " + listaDati[i].tema + " - " + " Data: " + listaDati[i].data.ToString() + " - " + " Mosse: " + listaDati[i].mosseImpiegate.ToString() + " - " + " Tempo impiegato: " + listaDati[i].tempoImpiegato.ToString());
                    break;
                case 4: lbl5.Text += ("Tema: " + listaDati[i].tema + " - " + " Data: " + listaDati[i].data.ToString() + " - " + " Mosse: " + listaDati[i].mosseImpiegate.ToString() + " - " + " Tempo impiegato: " + listaDati[i].tempoImpiegato.ToString());
                    break;
                default:
                    break;
            }
            
        }            
    }
    private async void ToHome(object sender, EventArgs e)
    {
		await Navigation.PopToRootAsync();
    }
    public class Dati
    {
        public int mosseImpiegate { get; set; }
        public TimeSpan tempoImpiegato { get; set; }
        public DateTime data { get; set; }
        public Tema tema { get; set; }
    }
}