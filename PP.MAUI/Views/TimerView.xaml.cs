using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

public partial class TimerView : ContentPage
{
	public TimerView(int projectId, Window parentWindow)
	{
		InitializeComponent();
		BindingContext = new TimerViewModel(projectId, parentWindow);
	}
}