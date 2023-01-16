using _11_EsempioMVVM.ViewModel;
namespace _11_EsempioMVVM.View;

public partial class PeopleView : ContentPage
{
	public PeopleView()
	{
		InitializeComponent();
		BindingContext = new PeopleViewModel();
	}
}