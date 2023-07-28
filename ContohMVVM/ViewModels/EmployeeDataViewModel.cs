using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ContohMVVM.Models;

namespace ContohMVVM.ViewModels
{
	public class EmployeeDataViewModel : ObservableObject
	{
		readonly EmployeeData data;
        public ObservableCollection<Employee> Monkeys { get => data.Employees; }
        public EmployeeDataViewModel()
		{
            data = new EmployeeData();
        }
	}
}

