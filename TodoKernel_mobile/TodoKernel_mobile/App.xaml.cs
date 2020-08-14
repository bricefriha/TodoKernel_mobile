
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using CustardApi.Objects;
using TodoKernel_mobile.Models;
using TodoKernel_mobile.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoKernel_mobile
{
    public partial class App : Application
    {
        public static User UserSession { get; set; }
        public static Service WsHost { get; set; }
        public static NavigationPage Nav { get; set; }


        public App()
        {

            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new Page();

            UserSession = new User();

            // Set the webservice host
            WsHost = new Service("192.168.1.67");
        }

        protected override async void OnStart()
        {
            var oauthToken = string.Empty;
            // Find a user session
            try
            {
                 oauthToken = await SecureStorage.GetAsync("oauth_token");
            }
            catch (Exception ex)
            {
                
                // Possible that device doesn't support secure storage on device.
            }

            // If a token is find
            if (!string.IsNullOrEmpty(oauthToken))
            {
                // Set the header
                IDictionary<string, string> headers = new Dictionary<string, string>();

                // Fetch the user token
                headers.Add("Authorization", "Bearer " + oauthToken);

                // Set the user session from the token
                UserSession = await WsHost.ExecuteGet<User>("users", "current", headers);
                UserSession.Token = oauthToken;

                // Opening the main view
                MainPage = new AppShell();
            }
            else
                MainPage = new SignInPage();

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
