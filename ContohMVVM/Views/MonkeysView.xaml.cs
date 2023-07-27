using ContohMVVM.ViewModels;

namespace ContohMVVM.Views;

public partial class MonkeysView : ContentPage
{
	public MonkeysView(MonkeyDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
