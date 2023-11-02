using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set
			{
				if (_isBusy == value)
					return;
				_isBusy = value;
				OnPropertyChanged();
				// Also raise the IsNotBusy property changed
				OnPropertyChanged(nameof(IsNotBusy));
			}
		}

		public bool IsNotBusy => !IsBusy;

		string _title;
		public string Title
		{
			get => _title;
			set
			{
				if (_title == value)
					return;
				_title = value;
				OnPropertyChanged();
			}
		}
	}
}
