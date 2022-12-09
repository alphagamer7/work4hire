using CommunityToolkit.Mvvm.ComponentModel;
using work4hire.Model;

namespace work4hire.ViewModel;

[QueryProperty(nameof(Project), "Project")]
public partial class JobDetailsViewModel : BaseViewModel
{
	public JobDetailsViewModel()
	{
		
	}

	[ObservableProperty]
	Project project;
}
