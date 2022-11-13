using work4hire.Model;

namespace work4hire.Views;

public partial class LoginPage : ContentPage
{

    public LoginPage()
    {
        InitializeComponent();
    }

    async void OnLoginClicked(System.Object sender, System.EventArgs e)
    {
        var userDetails = new UserBasicInfo();
        userDetails.Email = "dsadas@daf.c";
        userDetails.RoleID = 1;
        userDetails.RoleText = "dsadas@daf.c";
        userDetails.FullName = "dsadas@daf.c";

        App.UserDetails = userDetails;

        await AppConstant.AddFlyoutMenusDetails();


    }
}


