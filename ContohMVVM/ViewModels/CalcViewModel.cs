using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ContohMVVM.ViewModels
{
	public class CalcViewModel : INotifyPropertyChanged
	{
		private int num1;
		private int num2;
		private int answer;

        public ICommand SumCommand { get; }

        public CalcViewModel()
        {
            SumCommand = new Command(OnSumCommand);
        }

        private void OnSumCommand(object obj)
        {
            Answer = Num1 + Num2;
        }

        public int Num1
		{
			get => num1;
			set
			{
				num1 = value;
				OnPropertyChanged(nameof(Num1));
			}
		}

        public int Num2
        {
            get => num2;
            set
            {
                num2 = value;
                OnPropertyChanged(nameof(Num2));
            }
        }

        public int Answer
        {
            get => answer;
            set
            {
                answer = value;
                OnPropertyChanged(nameof(Answer));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

