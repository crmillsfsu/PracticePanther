using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
		BindingContext = new ClientViewModel();
	}
}