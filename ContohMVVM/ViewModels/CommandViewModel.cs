using System;
using System.Windows.Input;

namespace ContohMVVM.ViewModels
{
	public class CommandViewModel
	{
        /*public ICommand BtnClickCommand =>
            new Command(() => App.Current.MainPage.DisplayAlert("First Command","You clicked the button","OK"));*/

        public ICommand BtnClickCommand { get; }
        public CommandViewModel()
        {
            BtnClickCommand = new Command(OnBtnClickCommand);
        }

        private void OnBtnClickCommand(object obj)
        {
            App.Current.MainPage.DisplayAlert("First Command", "You clicked the button", "OK");
        }
    }
}

