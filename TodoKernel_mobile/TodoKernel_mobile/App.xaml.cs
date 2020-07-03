using System;
using TodoKernel_mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoKernel_mobile
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            MainPage = new SignInPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
