﻿namespace work4hire.Views;

public partial class ProfilePage : ContentPage
{
    int count = 0;
	public ProfilePage(ViewModel.ProfilePageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }

    void editDetails(System.Object sender, System.EventArgs e)
    {



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

        

    }

    async void editProfilePic(System.Object sender, System.EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Image please",
            FileTypes = FilePickerFileType.Images

        }) ;

        if (result == null)
        {
            
            return;
        }

        var stream = await result.OpenReadAsync();
        ProfilePic.Source = ImageSource.FromStream(() => stream);

    }


}
