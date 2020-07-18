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

        //private void btnSignin_Clicked(object sender, EventArgs e)
        //{
        //    _vm.Authentificate();
        //}
    }
}