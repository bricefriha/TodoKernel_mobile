using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoKernel_mobile.Viewmodels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoKernel_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new TodolistViewModel();
        }

        private void Open_Form(object sender, EventArgs e)
        {
            // Get screen info
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            
            // Annimation
            Action<double> callback = input => AddItemForm.HeightRequest = input;
            double startHeight = 0;
            double endHeight = 120;//mainDisplayInfo.Height / 20;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.SinOut;
            AddItemForm.Animate("anim", callback, startHeight, endHeight, rate, length, easing);
        }
        /// <summary>
        ///  event if the user tap in the body
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Body_Tapped(object sender, EventArgs e)
        {
            if (AddItemForm.Height > 0)
            {
                Action<double> callback = input => AddItemForm.HeightRequest = input;
                double startHeight = 120;
                double endiendHeight = 0;
                uint rate = 32;
                uint length = 500;
                Easing easing = Easing.SinOut;
                AddItemForm.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);
            }
        }
    }
}