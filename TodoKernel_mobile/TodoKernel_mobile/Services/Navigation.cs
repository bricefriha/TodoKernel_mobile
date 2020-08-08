using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoKernel_mobile.Views;

namespace TodoKernel_mobile.Services
{
    public class Navigation : INavigationService
    {
        public  async Task ToMainpage ()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AppShell());
        }
        public  async Task ToAuthentication()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignInPage());
        }
    }
}
