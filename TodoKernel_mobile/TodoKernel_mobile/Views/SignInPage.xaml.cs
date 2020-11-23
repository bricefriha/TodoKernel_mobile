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
        private const int _mainFrameHeight = 400;
        private const int _mainFrameWidth = 320;
        private const int _mainFrameLoadingMode = 80;
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
        /// <summary>
        /// Animate the main frame
        /// </summary>
        /// <param name="isForward">True forward ¦ False Backward</param>
        public void AnimateMainFrame (bool isForward)
        {
            // Set the animation 
            //
            // Callbacks
            Action<double> callbackHeight = input => mainFrame.HeightRequest = input;
            Action<double> callbackWidth = input => mainFrame.WidthRequest = input;

            // pace at which aniation proceeds
            uint rate = 16;

            // one second animation
            const uint length = 700;
            Easing easing = Easing.Linear;

            // Animate forward
            if (isForward)
            {
                // Animation for the height
                mainFrame.Animate("animHeight", callbackHeight, _mainFrameHeight, _mainFrameLoadingMode, rate, length, easing);

                // Animation for the width
                mainFrame.Animate("animWidth", callbackWidth, _mainFrameWidth, _mainFrameLoadingMode, rate, length, easing);
            }
            else
            {
                // Animation for the height
                mainFrame.Animate("animHeight", callbackHeight, _mainFrameLoadingMode, _mainFrameHeight, rate, length, easing);

                // Animation for the width
                mainFrame.Animate("animWidth", callbackWidth, _mainFrameLoadingMode, _mainFrameWidth, rate, length, easing);
            }
            
        }

    }
}