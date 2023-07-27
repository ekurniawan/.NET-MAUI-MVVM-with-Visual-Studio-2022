using ContohMVVM.Services;
using ContohMVVM.ViewModels;
using ContohMVVM.Views;
using Microsoft.Extensions.Logging;

namespace ContohMVVM;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddSingleton<MonkeysView>();

		builder.Services.AddSingleton<MonkeyDetailsViewModel>();
		builder.Services.AddSingleton<DetailsView>();

		//platform API
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		return builder.Build();
	}
}

