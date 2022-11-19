using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Newtonsoft.Json;
using work4hire.Model;
using work4hire.Views;
using User = work4hire.Model.User;

namespace work4hire.ViewModel
{
	public partial class LoginPageViewModel : BaseViewModel
    {
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
                    var serializedContent = JsonConvert.SerializeObject(content);
                    Preferences.Set("FreshFirebaseToken", serializedContent);
                    var userDetails = new UserBasicInfo();
                    userDetails.Email = loginUser.Email;
                    userDetails.RoleID = 1;
                    userDetails.RoleText = loginUser.Email;
                    userDetails.FullName = "User";

                    App.UserDetails = userDetails;

                    await AppConstant.AddFlyoutMenusDetails();

                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                    throw;
                }


            }

        }
        #endregion
    }
}