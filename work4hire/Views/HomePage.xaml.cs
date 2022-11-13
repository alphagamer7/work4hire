using work4hire.Controls;

namespace work4hire.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
  
    }
}
