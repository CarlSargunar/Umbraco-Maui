# Runthrough - Part 1

1 - Delete the default MainPage.Xaml. 
    - Add a new ContentPage (Xaml) called Views\MainPage.Xaml
    - Add a new ContentPage (Xaml) called Views\DetailPage.Xaml

2 - Modify the shell to include the namespace below, and set the ContentTemplate to MainPage

    xmlns:views="clr-namespace:MyMauiApp.Views"

        <ShellContent
        Title="Home"
        ContentTemplate="{DataTemplate views:MainPage}"
        Route="MainPage" />

3 - Add the Model for Product in the folder Models/Product.cs. Include the context for later

    public class Product
    {
        // Hard coded for demo
        private static readonly CultureInfo CultureInfo = new("en-GB"); 

        // I suppose this formatting counts as business logic?
        public string FormattedPrice => Price.ToString("C2", CultureInfo);

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string[] Category { get; set; }
    }

    [JsonSerializable(typeof(List<Product>))]
    internal sealed partial class ProductContext : JsonSerializerContext
    {

    }

4 - Add a product Service to the file Services/ProductService.cs

    public class ProductService
	{
		public ProductService()
		{
		}

		List<Product> productList;

		public async Task<List<Product>> GetProducts()
		{
			productList = new List<Product>();
			
            var prod1 = new Product
            {
                Name = "Product 1",
                Price = 10.99m,
                Sku = "SKU1",
                Image = "https://picsum.photos/id/101/200",
                Description = "Product 1 Description",
                Category = new string[] { "Category 1", "Category 2" }
            };
            productList.Add(prod1);

            var prod2 = new Product
            {
                Name = "Product 2",
                Price = 20.99m,
                Sku = "SKU2",
                Image = "https://picsum.photos/id/102/200",
                Description = "Product 2 Description",
                Category = new string[] { "Category 1", "Category 2" }
            };
            productList.Add(prod2);

            var prod3 = new Product
            {
                Name = "Product 3",
                Price = 30.99m,
                Sku = "SKU3",
                Image = "https://picsum.photos/id/103/200",
                Description = "Product 3 Description",
                Category = new string[] { "Category 1", "Category 2" }
            };
            productList.Add(prod3);

			return productList;
		}
	
	}

5 - Set up the service, as well as the main Page in the MauiProgram.cs

            // Add Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailPage>();

            // Add Services
            builder.Services.AddSingleton<Services.ProductService>();


6 - Add the following Xaml to Mainpage.Xaml

    <StackLayout>
        <ListView x:Name="ProductList" ItemTapped="ProductList_ItemTapped">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <StackLayout Orientation="Horizontal">
                            <Image Source="{Binding Image}" WidthRequest="200" HeightRequest="200" />
                            <StackLayout>
                                <Label Text="{Binding Name}" />
                                <Label Text="{Binding FormattedPrice}" />
                            </StackLayout>
                        </StackLayout>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </StackLayout>

7 - Add the code to the MainPage.Xaml.cs

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
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

        private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Product;
            Navigation.PushAsync(new DetailPage(product));
        }
    }            


8 - Add the following Markup to the DetailPage.Xaml

    <StackLayout>
        <Image Source="{Binding Image}" WidthRequest="200" HeightRequest="200" />
        <Label Text="{Binding Name}" />
        <Label Text="{Binding FormattedPrice}" />
        <Label Text="{Binding Description}" />
    </StackLayout>

9 - Add the following code to the DetailPage.Xaml.cs

    public partial class DetailPage : ContentPage
    {
        public DetailPage(Product product)
        {
            InitializeComponent();
            BindingContext = product;
        }
    }

Run the App    

