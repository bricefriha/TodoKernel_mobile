using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmHelpers;
using TodoKernel_mobile.Models;

namespace TodoKernel_mobile.Viewmodels
{
    public class TodolistViewModel : BaseViewModel
    {
        private ObservableCollection<Todolist> _todolists;
        public ObservableCollection<Todolist> Todolists
        {
            set
            {
                _todolists = value;
                OnPropertyChanged();
            }
            get
            {
                return _todolists;
            }

        }
        private Todolist _currentTodolist;
        public Todolist CurrentTodolist
        {
            set
            {
                _currentTodolist = value;
                OnPropertyChanged();
            }
            get
            {
                return _currentTodolist;
            }

        }
        private ObservableCollection<Item> _currentItems;
        public ObservableCollection<Item> CurrentItems
        {
            set
            {
                _currentItems = value;
                OnPropertyChanged();
            }
            get
            {
                return _currentItems;
            }

        }
        private Xamarin.Forms.Command _switchTodolist;
        public Xamarin.Forms.Command SwitchTodolist
        {

            get
            {
                return _switchTodolist;
            }
        }
        public TodolistViewModel ()
        {
            _todolists = new ObservableCollection<Todolist>();

            _switchTodolist = new Xamarin.Forms.Command(async (id) => {
                // Set the header
                IDictionary<string, string> headers = new Dictionary<string, string>();
                // Fetch the user token
                headers.Add("Authorization", "Bearer " + App.userSession.Token);

                // define the body
                string body = " { \"todolistId\": \"" + id + " } ";

                CurrentItems = await App.WsHost.ExecuteGet<ObservableCollection<Item>>("todos", "get", headers, body);
            });
            FetchTodolist();
        }

        // Get all todo lists
        public async void FetchTodolist()
        {
            // Set the header
            IDictionary<string, string> headers = new Dictionary<string, string>();

            // Fetch the user token
            headers.Add("Authorization", "Bearer " + App.userSession.Token);

            // Request the server
            Todolists = await App.WsHost.ExecuteGet<ObservableCollection<Todolist>>("todolists", null, headers);

            CurrentItems = new ObservableCollection<Item>();
            _currentTodolist = new Todolist();

            // Set the first todolist's items a the current items
            CurrentItems = Todolists[0].Items;
            //CurrentTodolist = Todolists[0];

        }
    }
}
