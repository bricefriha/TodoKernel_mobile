using CustardApi.Objects;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoKernel_mobile.Models;
using TodoKernel_mobile.ToolBox;
using Xamarin.Essentials;

namespace TodoKernel_mobile.Viewmodels
{
    public class SignInViewModel : BaseViewModel
    {
        private string _loadingState;
        public string LoadingState
        {
            set
            {
                _loadingState = value;
                OnPropertyChanged();
            }
            get
            {
                return _loadingState;
            }
        }
        private string _login;
        public string Login
        {
            set
            {
                _login = value;
                OnPropertyChanged();
            }
            get
            {
                return _login;
            }
        }
        private string _password;
        public string Password
        {
            set
            {
                _password = value;
                OnPropertyChanged();
            }
            get
            {
                return _password;
            }
        }
        private Command _signIn;
        public Command SignIn
        {
            
            get
            {
                return _signIn;
            }
        }
        public SignInViewModel()
        {
            _signIn = new Command(async () =>
            {
                string body;

                // Detect if the login is a username or an email
                if (Util.DetectEmail(Login))
                    // Define the body in Json 
                    body = " { \"email\": \"" + Login + "\", \"password\": \"" + Password + "\" } ";
                else
                    // Define the body in Json 
                    body = " { \"username\": \"" + Login + "\", \"password\": \"" + Password + "\" } ";

                // Execute the request
                App.userSession = await App.WsHost.ExecutePost<User>("users", "authenticate", null, body);

                LoadingState = "Logged in";
            });

            Login = "brice.friha@outlook.com";
            Password = "pwd";
        }
    }
}
