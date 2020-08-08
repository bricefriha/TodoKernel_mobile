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
    public partial class AppShell : Shell
    {
        private TodolistViewModel _vm;
        public AppShell()
        {
            InitializeComponent();

            BindingContext = _vm = new TodolistViewModel ();

            CurrentItem = ItemsPage;

        }
    }
}