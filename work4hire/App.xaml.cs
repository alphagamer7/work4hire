using work4hire.Services;

namespace work4hire;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        DependencyService.Register<WebClientService>();
        DependencyService.Register<FirebaseDataStore>();

        MainPage = new AppShell();
	}
}

