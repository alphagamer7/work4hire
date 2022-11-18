using work4hire.Model;
using Microsoft.Maui.Controls;
using System;
using Firebase.Auth;
using Newtonsoft.Json;
using work4hire.ViewModel;

namespace work4hire.Views;

public partial class LoginPage : ContentPage
{
    public string webApiKey = "AIzaSyB3NAEFWuXtyP7iGvxJCz8Bs7TA7EGFo7E";
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }


    void OnTapGestureRecognizerTapped(object sender, EventArgs args)
    {
        handleNavigation();
    }

    async void handleNavigation()
    {
        await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
    }

}


