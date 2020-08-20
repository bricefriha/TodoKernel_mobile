using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoKernel_mobile.Models;
using TodoKernel_mobile.Viewmodels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoKernel_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        private TodolistViewModel _vm;
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _vm = new TodolistViewModel();
        }

        private void Open_Form_item(object sender, EventArgs e)
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

            // Close the other side bar if this one is opened
            if (AddTodolistForm.Height > 0)
            {
                HideTopSlideBar();
            }
        }
        private void Open_Form_Todolist(object sender, EventArgs e)
        {
            // Get screen info
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;


            // Annimation
            Action<double> callback = input => AddTodolistForm.HeightRequest = input;
            double startHeight = 0;
            double endHeight = 120;//mainDisplayInfo.Height / 20;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.SinOut;
            AddItemForm.Animate("anim", callback, startHeight, endHeight, rate, length, easing);

            // Close the other side bar if this one is opened
            if (AddItemForm.Height > 0)
            {
                HideBottomSlideBar();
            }
        }
        /// <summary>
        ///  event if the user tap in the body
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_Form(object sender, EventArgs e)
        {
            if (AddItemForm.Height > 0)
            {
                // hide the bottom slide bar
                HideBottomSlideBar();
            }
            else if (AddTodolistForm.Height > 0)
            {
                HideTopSlideBar();
            }
        }
        /// <summary>
        /// Method to hide the bottom slide bar
        /// </summary>
        private void HideBottomSlideBar()
        {
            Action<double> callback = input => AddItemForm.HeightRequest = input;
            double startHeight = 120;
            double endiendHeight = 0;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.SinOut;
            AddItemForm.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);
        }
        /// <summary>
        /// Method to hide the bottom slide bar
        /// </summary>
        private void HideTopSlideBar()
        {
            Action<double> callback = input => AddTodolistForm.HeightRequest = input;
            double startHeight = 120;
            double endiendHeight = 0;
            uint rate = 32;
            uint length = 500;
            Easing easing = Easing.SinOut;
            AddItemForm.Animate("anim", callback, startHeight, endiendHeight, rate, length, easing);
        }


    }
}