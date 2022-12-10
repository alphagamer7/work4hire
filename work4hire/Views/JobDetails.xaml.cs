using work4hire.ViewModel;

namespace work4hire.Views;

public partial class JobDetails : ContentPage
{
	public JobDetails(JobDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    async void OnCancelClicked(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
