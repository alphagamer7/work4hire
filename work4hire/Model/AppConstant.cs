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
        public static string WebApiKey = "AIzaSyB3NAEFWuXtyP7iGvxJCz8Bs7TA7EGFo7E";
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
                        Title = "Admin Dashboard",
                        ContentTemplate = new DataTemplate(typeof(HomePage)),
                    },
                    new ShellContent
                    {
                        Icon = "about_us.png",
                        Title = "Profile",
                        ContentTemplate = new DataTemplate(typeof(HomePage)),
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
