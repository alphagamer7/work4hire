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
    public partial class HomePageViewModel
    {

        public IFirebaseDataStore<User> DataStore => DependencyService.Get<IFirebaseDataStore<User>>();

        public HomePageViewModel()
        {
            try
            {
                this.DataStore.GetProjectList();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           

        }



        #region Commands
        [RelayCommand]
        async void FabIconClick()
        {
            try
            {
                this.DataStore.GetProjectList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            await Shell.Current.GoToAsync($"//{nameof(AddJobPage)}");
        }
        #endregion
    }
}