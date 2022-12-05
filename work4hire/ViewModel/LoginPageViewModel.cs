using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Newtonsoft.Json;
using work4hire.Model;
using work4hire.Services;
using work4hire.Views;
using User = work4hire.Model.User;

namespace work4hire.ViewModel
{
	public partial class LoginPageViewModel : BaseViewModel
    {

        public IFirebaseDataStore<User> DataStore => DependencyService.Get<IFirebaseDataStore<User>>();

        public string webApiKey = AppConstant.WebApiKey;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        #region Commands
        [RelayCommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                User loginUser = new User(Email, Password);
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                try
                {
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(loginUser.Email, loginUser.Password);
                    var content = await auth.GetFreshAuthAsync();
                    Preferences.Set("FirebaseToken", JsonConvert.SerializeObject(content)); // storing firebase token in maui storage

                    var userDetails = new UserBasicInfo();
                    User user = await DataStore.LoginUser(loginUser);

                    App.UserDetails = userDetails;
                    userDetails.Email = user.Email;
                    userDetails.RoleID = user.Status;
                    userDetails.RoleText = "User";
                    userDetails.FullName = user.FirstName+" "+user.LastName;
                    Preferences.Set("user", JsonConvert.SerializeObject(content)); // storing firebase token in maui storage
                    await AppConstant.AddFlyoutMenusDetails();
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Invalid username or password", "OK");
                }
            }

        }
        #endregion
    }
}