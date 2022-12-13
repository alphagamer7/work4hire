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
    ProfilePageViewModel viewModel;

    public ProfilePage(ProfilePageViewModel viewModel)
    {

        this.BindingContext = viewModel;
        this.viewModel = viewModel;

        InitializeComponent();
        FirstName.Text = this.viewModel._firstName;
        LastName.Text = this.viewModel._lastName;
        if (!string.IsNullOrEmpty(this.viewModel.ProfileImage))
        {
            ProfilePic.Source = this.viewModel.ProfileImage;
        }
    }

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
                    viewModel.ProfileImage = downloadLink;


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
                    viewModel.ProfileImage = downloadLink;

                } // if the exception found
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

    }
}