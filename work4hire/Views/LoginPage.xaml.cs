using work4hire.Model;
using Microsoft.Maui.Controls;
using System;

namespace work4hire.Views;

public partial class LoginPage : ContentPage
{

    public LoginPage()
    {
        InitializeComponent();
    }

    async void OnLoginClicked(Object sender, EventArgs e)
    {
        var userDetails = new UserBasicInfo();
        userDetails.Email = "dsadas@daf.c";
        userDetails.RoleID = 1;
        userDetails.RoleText = "dsadas@daf.c";
        userDetails.FullName = "dsadas@daf.c";

        App.UserDetails = userDetails;

        await AppConstant.AddFlyoutMenusDetails();


    }


    void OnTapGestureRecognizerTapped(object sender, EventArgs args)
    {
        Console.Write("test");
        handleNavigation();
    }

    async void handleNavigation()
    {
        await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
    }

}


