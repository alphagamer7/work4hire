using Newtonsoft.Json;
using work4hire.ViewModel;
using work4hire.Views;

namespace work4hire;

public partial class AppShell : Shell
{
    public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new AppShellViewModel();
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    public async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        if (e.NetworkAccess == NetworkAccess.ConstrainedInternet)
            Console.WriteLine("Internet access is available but is limited.");

        else if (e.NetworkAccess != NetworkAccess.Internet)
        {
            Console.WriteLine("Internet access has been lost.");
            await App.Current.MainPage.DisplayAlert("Alert", "No internet connection. Please reconnect and try again.", "OK");
        }
    }

    //clear storage values and logout.
    async void HandleSignOut(Object sender,EventArgs e)
    {
        Preferences.Set("FirebaseToken", "");
        Preferences.Set("user", "");
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}

