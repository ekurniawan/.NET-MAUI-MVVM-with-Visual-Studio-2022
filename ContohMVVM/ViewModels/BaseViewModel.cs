using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ContohMVVM.ViewModels
{
	public partial class BaseViewModel : ObservableObject
	{
		public BaseViewModel()
		{
		}

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(isNotBusy))]
		bool isBusy;

		[ObservableProperty]
		string title;

		public bool isNotBusy => !IsBusy;
	}
}

