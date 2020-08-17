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
            double endHeight = mainDisplayInfo.Height / 15;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.CubicOut;
            AddItemForm.Animate("anim", callback, startHeight, endHeight, rate, length, easing);

            //
            //if (MyDraggableView.Height == 0)
            //{
            //}
            //else
            //{
            //    Action<double> callback = input => MyDraggableView.HeightRequest = input;
            //    double startHeight = mainDisplayInfo.Height / 3;
            //    double endiendHeight = 0;
            //    uint rate = 32;
            //    uint length = 500;
            //    Easing easing = Easing.SinOut;
            //    MyDraggableView.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);

            //}
        }
    }
}