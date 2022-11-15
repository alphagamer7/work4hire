using System;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using work4hire.Model;
using work4hire.Services;

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
                User newUser = new User(FirstName, LastName,Password, Email, "97 ashgove", "");
                DataStore.RegisterUser(newUser);
            }
          


        //
            //if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(Password))
            //{
            //    var userDetails = new UserBasicInfo();
            //    userDetails.Email = Email;
            //    userDetails.FullName = "Test User Name";

            //    // Student Role, Teacher Role, Admin Role,
            //    if (Email.ToLower().Contains("student"))
            //    {
            //        userDetails.RoleID = (int)RoleDetails.Student;
            //        userDetails.RoleText = "Student Role";
            //    }
            //    else if (Email.ToLower().Contains("teacher"))
            //    {
            //        userDetails.RoleID = (int)RoleDetails.Teacher;
            //        userDetails.RoleText = "Teacher Role";
            //    }
            //    else
            //    {
            //        userDetails.RoleID = (int)RoleDetails.Admin;
            //        userDetails.RoleText = "Admin Role";
            //    }


            //    // calling api 


            //    if (Preferences.ContainsKey(nameof(App.UserDetails)))
            //    {
            //        Preferences.Remove(nameof(App.UserDetails));
            //    }

            //    string userDetailStr = JsonConvert.SerializeObject(userDetails);
            //    Preferences.Set(nameof(App.UserDetails), userDetailStr);
            //    App.UserDetails = userDetails;
            //    await AppConstant.AddFlyoutMenusDetails();
            //}


        }
        #endregion


    }
}

