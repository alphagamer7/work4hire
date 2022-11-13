using Microsoft.Maui.Platform;
using work4hire.Services;

namespace work4hire;

public partial class App : Application
{
    public static UserBasicInfo UserDetails;
    public App()
	{
		InitializeComponent();

        DependencyService.Register<WebClientService>();
        DependencyService.Register<FirebaseDataStore>();

        MainPage = new AppShell();

    }


}

public class UserBasicInfo
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public int RoleID { get; set; }
    public string RoleText { get; set; }
}

public enum RoleDetails
{
    Student = 1,
    Teacher,
    Admin,
}

