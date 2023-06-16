using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

public partial class ClientDetailView : ContentPage
{
	public ClientDetailView()
	{
		InitializeComponent();
		BindingContext = new ClientViewModel();
	}

    private void OkClicked(object sender, EventArgs e)
    {
		(BindingContext as ClientViewModel).Add();
		Shell.Current.GoToAsync("//Clients");
    }
}