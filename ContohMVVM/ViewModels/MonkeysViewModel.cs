using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public ObservableCollection<Monkey> Monkeys { get; } = new();
        public MonkeysViewModel(MonkeyService monkeyService,IConnectivity connectivity)
		{
			Title = "Monkey Finder";
			this.monkeyService = monkeyService;
			this.connectivity = connectivity;
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
			}
		}

	}
}

