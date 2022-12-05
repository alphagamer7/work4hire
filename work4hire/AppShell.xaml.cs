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
    }

    //clear storage values and logout.
    async void HandleSignOut(Object sender,EventArgs e)
    {
        Preferences.Set("FirebaseToken", "");
        Preferences.Set("user", "");
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}

