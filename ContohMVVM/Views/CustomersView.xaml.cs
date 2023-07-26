using ContohMVVM.ViewModels;

namespace ContohMVVM.Views;

public partial class CustomersView : ContentPage
{
	public CustomersView()
	{
		InitializeComponent();
		BindingContext = new CustomersViewModel();
	}
}
