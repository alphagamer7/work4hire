using work4hire.Controls;
using work4hire.Model;
using work4hire.ViewModel;

namespace work4hire.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var project = ((VisualElement)sender).BindingContext as Project;
        if (project == null)
            return;

        await Shell.Current.GoToAsync($"//{nameof(JobDetails)}", true,new Dictionary<string, object> { { "Project", project } });

    }
}
