using ContohMVVM.ViewModels;

namespace ContohMVVM.Views;

public partial class CommandView : ContentPage
{
	public CommandView()
	{
		InitializeComponent();
		BindingContext = new CommandViewModel();
	}
}
