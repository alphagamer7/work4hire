using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using work4hire.Model;
using work4hire.Services;
using work4hire.Views;
using User = work4hire.Model.User;

namespace work4hire.ViewModel
{
    public partial class HomePageViewModel
    {
        public ObservableRangeCollection<Project> Projects { get; set; }
        public IFirebaseDataStore<User> DataStore => DependencyService.Get<IFirebaseDataStore<User>>();
        public AsyncCommand PageAppearingCommand { get; }

        public HomePageViewModel()
        {
            try
            {
                this.DataStore.GetProjectList();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Projects = new ObservableRangeCollection<Project>();
            PageAppearingCommand = new AsyncCommand(PageAppearing);


        }

        public async Task Refresh()
        {

            var projects = await DataStore.GetProjectList();
            Projects.Clear();
            Projects.AddRange(projects);
        }

        async Task PageAppearing()
        {
            await Refresh();
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