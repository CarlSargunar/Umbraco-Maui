# Runthrough - Part 2

1 - Add a reference to CommunityToolkit.Mvvm

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

3 - Replace the content for BaseViewModel. This will use the Source Generator to generate the code for the properties. Note it's a partial

    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }

You can see the generated code under Dependancies -> .net7-XX -> Analysers -> CommunityToolkit.Mvvm.SourceGenerators -> CommunityToolkit.Mvvm.SourceGenerators.ObservabalePropertyGenerators -> MyMauiApp.Viewmodels.BaseViewModel.g.cs

4 - Add a new class called ViewModels\ProductsViewModel.cs

	public partial class ProductsViewModel : BaseViewModel
	{
		// An observable collection will notify the UI when items are added or removed
		public ObservableCollection<Product> Products { get; } = new();

		ProductService _productService;
		IConnectivity _connectivity;

		public ProductsViewModel(ProductService productService, IConnectivity connectivity)
		{
			Title = "Maui Shop";
			_productService = productService;
			_connectivity = connectivity;
		}

		[RelayCommand]
		async Task GoToDetails(Product product)
		{
			if (product == null)
				return;

			await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
			{
				{"Product", product }
			});
		}

		[RelayCommand]
		async Task GetProductFromContentDelivery()
		{
			if (IsBusy)
				return;

			try
			{
				if (_connectivity.NetworkAccess != NetworkAccess.Internet)
				{
					await Shell.Current.DisplayAlert("No connectivity!",
						$"Please check internet and try again.", "OK");
					return;
				}

				IsBusy = true;
				var newProducts = await _productService.GetProducts();

				if (Products.Count != 0)
					Products.Clear();

				foreach (var product in newProducts)
					Products.Add(product);

			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to get products: {ex.Message}");
				// Hacky way of showing an error - relax, it's a demo
				await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}

	}

5 - Replace the contents of Mainpage.cs with the following

	public MainPage(ProductsViewModel productsViewModel)
	{
		// Set the Binding Context on the constructor to hook it all up
		BindingContext = productsViewModel;
		InitializeComponent();
	}

    protected override async void OnAppearing()
	{
		base.OnAppearing();

		var productService = Application.Current.MainPage
			.Handler
			.MauiContext
			.Services
			.GetService<ProductService>();

		var products = await productService.GetProducts();
		ProductList.ItemsSource = products;
	}

6 - Replace the contents of MainPage.xaml with the following


7 - Inject the ProductsViewModel into the constructor of App.xaml.cs

    // Add Hardware Services
    builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

    // Add ViewModels
    builder.Services.AddSingleton<ViewModels.ProductsViewModel>();

