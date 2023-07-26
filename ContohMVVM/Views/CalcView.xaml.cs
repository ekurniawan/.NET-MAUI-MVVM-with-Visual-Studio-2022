using ContohMVVM.ViewModels;

namespace ContohMVVM.Views;

public partial class CalcView : ContentPage
{
	public CalcView()
	{
		InitializeComponent();
		BindingContext = new CalcViewModel();
	}
}
