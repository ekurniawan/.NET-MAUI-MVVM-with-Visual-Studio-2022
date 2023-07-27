using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using ContohMVVM.Models;
using ContohMVVM.Services;

namespace ContohMVVM.ViewModels
{
	public partial class MonkeyDetailsViewModel : BaseViewModel
	{
        private readonly MonkeyService monkeyService;
		public ObservableCollection<Monkey> Monkeys { get; } = new();
        public MonkeyDetailsViewModel(MonkeyService monkeyService)
		{
			Title = "Monkey Finder";
			this.monkeyService = monkeyService;
		}

		[RelayCommand]
		async Task GetMonkeysAsync()
		{
			if (IsBusy)
				return;

			try
			{
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

