using PP.Library.Services;
using PP.MAUI.ViewModels;
namespace PP.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailView : ContentPage
{
	public int ClientId { get; set; }
    public ClientDetailView()
	{
		InitializeComponent();
	}

    private void OkClicked(object sender, EventArgs e)
    {
		(BindingContext as ClientViewModel).AddOrUpdate();
		Shell.Current.GoToAsync("//Clients");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
    }
}