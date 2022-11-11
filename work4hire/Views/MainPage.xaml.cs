
namespace work4hire.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();






    }


    async void OnLoginClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }
}


