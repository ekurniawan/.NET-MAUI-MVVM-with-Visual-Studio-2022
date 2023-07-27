using ContohMVVM.ViewModels;

namespace ContohMVVM.Views;

public partial class DetailsView : ContentPage
{
	public DetailsView(MonkeyDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
