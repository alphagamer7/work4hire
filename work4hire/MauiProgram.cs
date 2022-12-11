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
                fonts.AddFont("FiraSans-Light.ttf", "RegularFont");
                fonts.AddFont("FiraSans-Medium.ttf", "MediumFont");
            });

        //pages
	    builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<AddJobPage>();
        builder.Services.AddSingleton<Favourites>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<JobDetails>();

        //View model
        builder.Services.AddSingleton<AppShellViewModel>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddSingleton<AddJobsViewModel>();
        builder.Services.AddSingleton<ProfilePageViewModel>();
        builder.Services.AddSingleton<JobDetailsViewModel>();

        return builder.Build();
	}
}

