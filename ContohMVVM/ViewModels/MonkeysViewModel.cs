using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContohMVVM.Models;
using ContohMVVM.Services;
using ContohMVVM.Views;

namespace ContohMVVM.ViewModels
{
	public partial class MonkeysViewModel : BaseViewModel
	{
        private readonly MonkeyService monkeyService;
        private readonly IConnectivity connectivity;
        private readonly IGeolocation geolocation;

		[ObservableProperty]
		bool isRefreshing;

        public ObservableCollection<Monkey> Monkeys { get; } = new();
        public MonkeysViewModel(MonkeyService monkeyService,IConnectivity connectivity,
			IGeolocation geolocation)
		{
			Title = "Monkey Finder";
			this.monkeyService = monkeyService;
			this.connectivity = connectivity;
			this.geolocation = geolocation;
		}

		[RelayCommand]
		async Task GoToDetails(Monkey monkey)
		{
			if (monkey == null)
				return;
			await Shell.Current.GoToAsync(nameof(DetailsView), true,
				new Dictionary<string, object>
				{
					{"Monkey",monkey }
				});
		}

		[RelayCommand]
		async Task GetClosestMonkeyAsync()
		{
			if (IsBusy || Monkeys.Count == 0)
				return;
			try
			{
				var location = await geolocation.GetLastKnownLocationAsync();
				if(location==null)
				{
					location = await geolocation.GetLocationAsync(
                    new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
				var first = Monkeys.OrderBy(m => location.CalculateDistance(new Location(m.Latitude,m.Longitude),
					DistanceUnits.Miles)).FirstOrDefault();
				await Shell.Current.DisplayAlert("", first.Name + " " + first.Location, "OK");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Shell.Current.DisplayAlert("Error", $"Tidak bisa dapat info lokasi {ex.Message}", "OK");
			}
		}

		[RelayCommand]
		async Task GetMonkeysAsync()
		{
			if (IsBusy)
				return;

			try
			{
				if(connectivity.NetworkAccess != NetworkAccess.Internet)
				{
					await Shell.Current.DisplayAlert("Masalah pada koneksi internet !", "Cek koneksi anda", "OK");
					return;
				}

				IsBusy = true;
				var monkeys = await monkeyService.GetMonkeys();
				if (Monkeys.Count != 0)
					Monkeys.Clear();

				foreach(var monkey in monkeys)
				{
					Monkeys.Add(monkey);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error: {ex.Message}");
				await Shell.Current.DisplayAlert("Error!", $"Gagal load data Monkeys {ex.Message}", "OK");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

	}
}

