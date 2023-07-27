using System;
using CommunityToolkit.Mvvm.ComponentModel;
using ContohMVVM.Models;

namespace ContohMVVM.ViewModels
{
	public partial class MonkeyDetailsViewModel : BaseViewModel
	{
		public MonkeyDetailsViewModel()
		{
			Title = "Monkey Detail";
		}

		[ObservableProperty]
		Monkey monkey;
	}
}

