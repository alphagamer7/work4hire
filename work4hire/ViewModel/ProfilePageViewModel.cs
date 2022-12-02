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
    public partial class ProfilePageViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _contactNo;





        



        //public string firstname = "Shubham";
        //public string lastname = "Dhamane";
        //public string email = "xvy@mycambrian.ca";
        //public string contactNo = "+1 333 333 3333";

        #region Commands
        [RelayCommand]
        async void Submit()
        {
            Console.Write(FirstName);
            Console.Write(LastName);
            Console.Write(Email);
            Console.Write(ContactNo);
        }
        #endregion

        private void GetProfileInfo()
        {
            var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
            _email = userInfo.User.Email;
        }


    }
    
}

