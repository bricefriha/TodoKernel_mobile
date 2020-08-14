using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoKernel_mobile.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoKernel_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private SignInViewModel _vm;


        public SignInPage()
        {
            InitializeComponent();

            // Binding
            BindingContext = _vm = new SignInViewModel();
        }
        /// <summary>
        /// Trigered when we click on sign in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSignin_Clicked(object sender, EventArgs e)
        {
            // Try to connect the user
            //App.userSession = await _vm.LogIn(); 

            // If the user as been identified
            if (App.UserSession != null)
            {
                // Navigate to the main page
                //await this.Navigation.PushAsync(new AppShell());
                App.Current.MainPage = new NavigationPage (new AppShell());
            }
        }

    }
}