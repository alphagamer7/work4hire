using work4hire.ViewModel;

namespace work4hire.Views;

public partial class JobDetails : ContentPage
{
	public JobDetails(JobDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
