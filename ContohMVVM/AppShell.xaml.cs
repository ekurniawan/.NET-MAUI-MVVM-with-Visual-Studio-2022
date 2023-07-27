using ContohMVVM.Views;

namespace ContohMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DetailsView), typeof(DetailsView));
	}
}

