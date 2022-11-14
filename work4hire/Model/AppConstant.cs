using work4hire.Controls;
using work4hire.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace work4hire.Model
{
    public class AppConstant
    {

        public async static Task AddFlyoutMenusDetails()
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

            var studentDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(HomePage)).FirstOrDefault();
            if (studentDashboardInfo != null) AppShell.Current.Items.Remove(studentDashboardInfo);


            var flyoutItem = new FlyoutItem()
            {
                Title = "Dashboard Page",
                Route = nameof(HomePage),
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                    {
                    new ShellContent
                    {
                        Icon = "dashboard.png",
                        Title = "Home",
                        ContentTemplate = new DataTemplate(typeof(HomePage)),
                    },
                    new ShellContent
                    {
                        Icon = "user.png",
                        Title = "Profile",
                        ContentTemplate = new DataTemplate(typeof(ProfilePage)),
                    },
                     new ShellContent
                    {
                        Icon = "about_us.png",
                        Title = "Favourites",
                        ContentTemplate = new DataTemplate(typeof(favorites)),
                    },
                   }
            };
            if (!AppShell.Current.Items.Contains(flyoutItem))
            {
                AppShell.Current.Items.Add(flyoutItem);

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }
    }
}
