using System;
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
    public partial class AddJobsViewModel : BaseViewModel
    {

        public IFirebaseDataStore<User> DataStore => DependencyService.Get<IFirebaseDataStore<User>>();

        [ObservableProperty]
        private string _category;

    //    <Label Text = "Category" TextColor="#480032"/>
				//<Entry Text = "{Binding Category}" x:Name="Category"/>
				//<Label Text = "Title"  TextColor="#480032"  />
				//<Entry Text = "{Binding Title}" x:Name="Title" />
				//<Label Text = "Description" TextColor="#480032" />

        [ObservableProperty] 
        private string _jobTitle;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private string _image;

        public string DownloadImage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public AddJobsViewModel()
        {
        }

        //HandleCancelAdd
        #region Commands
        [RelayCommand]
        async void HandleCancelAdd()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        #endregion

        //AddJobCommand
        #region Commands
        [RelayCommand]
        async void AddJob()
        {
            if (!string.IsNullOrWhiteSpace(Category) && !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Description) && !string.IsNullOrWhiteSpace(DownloadImage))
            {
                try
                {
                    Project newProject = new Project(Category, Title, Description, DownloadImage, Latitude, Longitude);
                    await DataStore.AddProject(newProject);
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please fill all required fields and try again", "OK");
                }
            }

        }
        #endregion

        public async Task GetCurrentLocation()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                var _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;

                }
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine(ex);
            }
        }



        //gs://work4hire-8a56a.appspot.com

    }
}

