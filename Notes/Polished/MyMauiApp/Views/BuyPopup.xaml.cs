using CommunityToolkit.Maui.Views;

namespace MyMauiApp.Views;

public partial class BuyPopup : Popup
{
	public BuyPopup()
	{
        InitializeComponent();
        // layout is the name given to the control by x:Name
        BuyPopupLayout.WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width * 0.7;
        BuyPopupLayout.HeightRequest = DeviceDisplay.Current.MainDisplayInfo.Height * 0.25;
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}