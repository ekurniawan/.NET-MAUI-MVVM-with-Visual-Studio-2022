using ContohMVVM.Services;
using ContohMVVM.ViewModels;
using ContohMVVM.Views;
using Microsoft.Extensions.Logging;
using DevExpress.Maui;
using static Android.Provider.Contacts;

namespace ContohMVVM;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseDevExpress()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Add this code
		string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "people.db3");
        builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));
        builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddSingleton<MonkeysView>();

		builder.Services.AddSingleton<MonkeyDetailsViewModel>();
		builder.Services.AddSingleton<DetailsView>();

		//platform API
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);
		return builder.Build();
	}
}

