using work4hire.Model;
using System;
using work4hire.ViewModel;

namespace work4hire.Views;

public partial class RegisterPage : ContentPage
{
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
        _ = GetCurrentLocation();
        this.BindingContext = viewModel;
    }



    async void OnRegisterClicked(Object sender, EventArgs e)
    {

        //var userDetails = new UserBasicInfo();
        //userDetails.Email = "dsadas@daf.c";
        //userDetails.RoleID = 1;
        //userDetails.RoleText = "dsadas@daf.c";
        //userDetails.FullName = "dsadas@daf.c";

        //App.UserDetails = userDetails;

        //await AppConstant.AddFlyoutMenusDetails();
      

    }

    public async Task GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        }
        catch (Exception ex)
        {
            // Unable to get location
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }
}
