using System;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using work4hire.Model;
using work4hire.Services;
using work4hire.Views;

namespace work4hire.ViewModel
{
    public partial class RegisterViewModel: BaseViewModel
    {
        public IFirebaseDataStore<User> DataStore => DependencyService.Get<IFirebaseDataStore<User>>();

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;


        #region Commands
        [RelayCommand]
        async void Register()
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(Password))
            {
                //TODO: add dynamic address
                User newUser = new User(FirstName, LastName,Password, Email, "97 ashgove", "");
                await DataStore.RegisterUser(newUser);
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }

        }
        #endregion


    }
}

