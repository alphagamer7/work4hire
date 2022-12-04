using work4hire.Model;
using Microsoft.Maui.Controls;
using System;
using Firebase.Auth;
using Newtonsoft.Json;
using work4hire.ViewModel;

namespace work4hire.Views;

public partial class AddJobPage : ContentPage
{
    public AddJobPage(AddJobsViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    async void handleNavigation()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

}


