using System;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ContohMVVM.ViewModels
{
	public partial class DataEditorViewModel : ObservableObject
    {
		[ObservableProperty]
        string notes = "";

		[ObservableProperty]
        DateTime? birthDate;

		[ObservableProperty]
		string phone;

		[ObservableProperty]
		string login = "";

		[ObservableProperty]
        bool loginHasError = false;

		[ObservableProperty]
        string password = "";

		[ObservableProperty]
        bool passwordHasError = false;

        public bool Validate()
        {
            PasswordHasError = !Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,}$");
            LoginHasError = String.IsNullOrEmpty(login);
            return !PasswordHasError && !LoginHasError;
        }

        [RelayCommand]
        async Task SubmitAsync()
        {
            if (Validate())
                await Shell.Current.DisplayAlert("Success", "Your account has been created successfully", "OK");
        }
	}
}

