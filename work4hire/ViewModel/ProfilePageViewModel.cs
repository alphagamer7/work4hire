using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        public event PropertyChangedEventHandler PropertyChanged;
        public IFirebaseDataStore<User> DataStore => DependencyService.Get<IFirebaseDataStore<User>>();

        [ObservableProperty]
        public string _firstName;

        [ObservableProperty]
        public string _lastName="fds";

        [ObservableProperty]
        public string _email="fsds";

        public ProfilePageViewModel()
        {
            GetProfileInfo();
            

        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        #region Commands
        [RelayCommand]
        void Submit()
        {
            var new_user = new User();
            new_user.FirstName = _firstName;
            new_user.LastName = _lastName;
            new_user.Email = _email;
            new_user.Address = "97 ashgove";
            new_user.Image = "";

            save_details(new_user);


            
        }

        public string GetFirstName
        {
            get => _firstName;
        }
        public string GetLastName
        {
            get => _lastName;
        }
        public string GetEmail
        {
            get => _email;
        }

        public async void save_details(User newUser)
        {


            //await DataStore.RegisterUser(newUser);

            

        }
        #endregion

        private void GetProfileInfo()
        {
            var userString = Preferences.Get("user", "");

            var userInfo = JsonConvert.DeserializeObject<User>(Preferences.Get("user", ""));
            _firstName = userInfo.FirstName;
            _lastName = userInfo.LastName;
            _email = userInfo.Email;
            OnPropertyChanged();
            //JsonConvert.DeserializeObject<UserResponse>(user);
            Console.Write(userString);
        }


    }
    
}

