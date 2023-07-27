using ContohMVVM.ViewModels;

namespace ContohMVVM.Views;

public partial class MonkeysView : ContentPage
{
	public MonkeysView(MonkeysViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
