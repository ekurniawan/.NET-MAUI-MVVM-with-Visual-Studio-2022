using ContohMVVM.ViewModels;

namespace ContohMVVM.Views;

public partial class CustomerView : ContentPage
{
	public CustomerView()
	{
		InitializeComponent();
		BindingContext = new CustomerViewModel();
	}
}
