using ContohMVVM.Views;

namespace ContohMVVM;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}

