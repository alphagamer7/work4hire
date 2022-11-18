using work4hire.Model;
using Microsoft.Maui.Controls;
using System;
using Firebase.Auth;
using Newtonsoft.Json;

namespace work4hire.Views;

public partial class LoginPage : ContentPage
{
    public string webApiKey = "AIzaSyB3NAEFWuXtyP7iGvxJCz8Bs7TA7EGFo7E";
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

        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
        try
        {
            var auth = await authProvider.SignInWithEmailAndPasswordAsync("tester22@gmail.com", "password");
            var content = await auth.GetFreshAuthAsync();
            var serializedContent = JsonConvert.SerializeObject(content);
            Preferences.Set("FreshFirebaseToken", serializedContent);
            //await this._navigation.PushAsync(new Dashboard());
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            throw;
        }


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


