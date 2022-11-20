using work4hire.Controls;
using work4hire.ViewModel;

namespace work4hire.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

}
