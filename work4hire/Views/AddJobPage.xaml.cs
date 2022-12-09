using work4hire.Model;
using Microsoft.Maui.Controls;
using System;
using Firebase.Auth;
using Newtonsoft.Json;
using work4hire.ViewModel;
using Firebase.Storage;
using Microsoft.Maui.Storage;

namespace work4hire.Views;

public partial class AddJobPage : ContentPage
{
    ImageSource imageStream;
    AddJobsViewModel viewModel;

    public AddJobPage(AddJobsViewModel viewModel)
    {   // start the defined components
        InitializeComponent();
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
        handleGeolocation(); // Geolocation manages the user's location
    }

    public void handleGeolocation()
    {
        _ = this.viewModel.GetCurrentLocation();
    }

    async void handleNavigation() // NavigationService provides the Navigation functionality
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

    // 
    async void AddJobImage(Object sender,EventArgs e)
    {
        string action = await DisplayActionSheet("Open With", "Cancel", null, "Camera", "Files");
        if (action == "Camera")
        {    // Options for choosing image
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                imageStream = ImageSource.FromStream(() => stream);
                JobImage.Source = imageStream;

                try
                {
                    var downloadLink = await new FirebaseStorage(AppConstant.FirebaseStorage).Child("Jobs/" + result.FileName).PutAsync(await result.OpenReadAsync());

                    Console.WriteLine(downloadLink);
                    viewModel.DownloadImage = downloadLink;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        

        }
        else if (action == "Files")
        { // choose the image
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Image please",
                FileTypes = FilePickerFileType.Images

            });

            if (result == null) return;

            if(result != null)
            {   // finding the source of the image
                var stream = await result.OpenReadAsync();
                imageStream = ImageSource.FromStream(() => stream);
                JobImage.Source = imageStream;
                try
                {   // store the image data in firebase
                    var downloadLink = await new FirebaseStorage(AppConstant.FirebaseStorage).Child("Jobs/" + result.FileName).PutAsync(await result.OpenReadAsync());
                    Console.WriteLine(downloadLink);
                    viewModel.DownloadImage = downloadLink;

                } // if the exception found
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}


