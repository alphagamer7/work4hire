using CommunityToolkit.Maui;
using work4hire.Services;
using work4hire.ViewModel;
using work4hire.Views;

namespace work4hire;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //pages
	builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<AddJobPage>();
        builder.Services.AddSingleton<favorites>();
        builder.Services.AddSingleton<ProfilePage>();

        //View model
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddSingleton<AddJobsViewModel>();
        builder.Services.AddSingleton<ProfilePageViewModel>();

        return builder.Build();
	}
}

