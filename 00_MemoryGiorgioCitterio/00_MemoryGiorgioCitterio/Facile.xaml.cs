namespace _00_MemoryGiorgioCitterio;

public partial class Facile : ContentPage
{
    static int clickTotal = 0;
	public Facile()
	{
		InitializeComponent();
	}

    private async void HasClicked(object sender, EventArgs e)
    {
        if(!(sender is ImageButton)) 
        {
            return;
        }
        ImageButton image = (ImageButton)sender;
        image.Clicked += async (sender, e) =>
        {
            clickTotal += 1;
            image.Source = "dotnet_bot.svg";
            await image.RotateTo(1000, 200);
            image.Rotation = 0;
        };


    }
}