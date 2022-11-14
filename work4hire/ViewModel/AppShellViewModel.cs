using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using work4hire.Views;

namespace work4hire.ViewModel
{
    public class AppShellViewModel
    {
        async void SignOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}

