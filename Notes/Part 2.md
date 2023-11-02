# Runthrough - Part 2

1 - Add a base Viewmodel to ViewModels/BaseViewModel.cs, and use the VS tools to implement the interface

    public class BaseViewModel : INotifyPropertyChanged

2 - Add the following fields to BaseViewModel


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

3 - Add the viewModels for ProductsViewModel.cs
