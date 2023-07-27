using System;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContohMVVM.Models;

namespace ContohMVVM.ViewModels
{
	[QueryProperty(nameof(Monkey), "Monkey")]
	public partial class MonkeyDetailsViewModel : BaseViewModel
	{
        private readonly IMap map;
        public MonkeyDetailsViewModel(IMap map)
		{
			Title = "Monkey Detail";
			this.map = map;
		}

		[RelayCommand]
		async Task OpenMapAsync()
		{
			try
			{
				await map.OpenAsync(Monkey.Latitude, Monkey.Longitude,
					new MapLaunchOptions
					{
						Name = Monkey.Name,
						NavigationMode = NavigationMode.None
					});
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "OK");
			}
		}

		[ObservableProperty]
		Monkey monkey;
        
    }
}

