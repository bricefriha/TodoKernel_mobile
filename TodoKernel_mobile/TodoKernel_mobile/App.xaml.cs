
using System;
using System.Net.Http.Headers;
using CustardApi.Objects;
using TodoKernel_mobile.Models;
using TodoKernel_mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoKernel_mobile
{
    public partial class App : Application
    {
        public static User userSession { get; set; }
        public static Service WsHost { get; set; }


        public App()
        {

            InitializeComponent();

            MainPage = new SignInPage();

            userSession = new User();

            // Set the webservice host
            WsHost = new Service("192.168.1.67");
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
