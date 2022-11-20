using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Newtonsoft.Json;
using work4hire.Model;
using work4hire.Views;

namespace work4hire.ViewModel
{
    public partial class HomePageViewModel
    {
        public HomePageViewModel()
        {
        }

        #region Commands
        [RelayCommand]
        async void FabIconClick()
        {
            await Shell.Current.GoToAsync($"//{nameof(AddJobPage)}");
        }
        #endregion
    }
}