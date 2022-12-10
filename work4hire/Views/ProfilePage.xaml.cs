using System;
using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using work4hire.ViewModel;
namespace work4hire.Views;
using Firebase.Storage;
using Firebase.Auth;

public partial class ProfilePage : ContentPage
{
    ImageSource imageStream;
    public ProfilePage(ViewModel.ProfilePageViewModel viewModel)
    {

        this.BindingContext = viewModel;
        InitializeComponent();
        //GetProfileInfoAsync();

    }
    //private async Task GetProfileInfoAsync()
    //{
    //    var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
    //    email.Text = userInfo.User.Email;
    //    firstName.Text = userInfo.User.FirstName;
    //    lastName.Text = userInfo.User.LastName;

    //}
    //void editDetails(System.Object sender, System.EventArgs e)
    //{



    //if (count == 0) {

    //    firstName.IsEnabled = true;
    //    lastName.IsEnabled = true;
    //    contactNo.IsEnabled = true;
    //    email.IsEnabled = true;

    //    edit.Text = "Save";
    //    count = 1;
    //}
    //else
    //{
    //    firstName.IsEnabled = false;
    //    lastName.IsEnabled = false;
    //    contactNo.IsEnabled = false;
    //    email.IsEnabled = false;

    //    edit.Text = "Edit";

    //    count = 0;
    //}



    //}

    async void editProfilePic(System.Object sender, System.EventArgs e)
    {
        string action = await DisplayActionSheet("Open With", "Cancel", null, "Camera", "Files");
        if (action == "Camera")
        {    // Options for choosing image
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                imageStream = ImageSource.FromStream(() => stream);
                ProfilePic.Source = imageStream;

                try
                {
                    var downloadLink = await new FirebaseStorage(Model.AppConstant.FirebaseStorage).Child("Profiles/" + result.FileName).PutAsync(await result.OpenReadAsync());

                    Console.WriteLine(downloadLink);
                    //viewModel.DownloadImage = downloadLink;


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

            if (result != null)
            {   // finding the source of the image
                var stream = await result.OpenReadAsync();
                imageStream = ImageSource.FromStream(() => stream);
                ProfilePic.Source = imageStream;
                try
                {   // store the image data in firebase
                    var downloadLink = await new FirebaseStorage(Model.AppConstant.FirebaseStorage).Child("Profiles/" + result.FileName).PutAsync(await result.OpenReadAsync());
                    Console.WriteLine(downloadLink);
                    //viewModel.DownloadImage = downloadLink;

                } // if the exception found
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

    }
}