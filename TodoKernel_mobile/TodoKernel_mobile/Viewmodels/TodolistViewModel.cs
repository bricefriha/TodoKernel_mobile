using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MvvmHelpers;
using TodoKernel_mobile.Models;

namespace TodoKernel_mobile.Viewmodels
{
    public class TodolistViewModel : BaseViewModel
    {
        private string _formTitle;
        public string FormTitle
        {
            set
            {
                _formTitle = value;
                OnPropertyChanged();
            }
            get
            {
                return _formTitle;
            }
        }
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

                // Execute the command
                SwitchTodolist.Execute(CurrentTodolist.Id);

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
        private Xamarin.Forms.Command _addItem;
        public Xamarin.Forms.Command AddItem
        {

            get
            {
                return _addItem;
            }
        }
        private Xamarin.Forms.Command _tickItem;
        public Xamarin.Forms.Command TickItem
        {

            get
            {
                return _tickItem;
            }
        }
        public TodolistViewModel ()
        {
            _todolists = new ObservableCollection<Todolist>();

            _switchTodolist = new Xamarin.Forms.Command(async (id) => {
                // Set the header
                IDictionary<string, string> headers = new Dictionary<string, string>();
                // Fetch the user token
                headers.Add("Authorization", "Bearer " + App.UserSession.Token);

                // define the body
                string body = " { \"todolistId\": \"" + id + "\" } ";

                CurrentItems = await App.WsHost.ExecuteGet<ObservableCollection<Item>>("todos", "get", headers, body);
            });

            _tickItem = new Xamarin.Forms.Command(async (id) => {

                // Get the selected item
                Item item = CurrentItems.Where<Item>(item => item.Id == id.ToString()).FirstOrDefault();

                // Set the header
                IDictionary<string, string> headers = new Dictionary<string, string>();
                // Fetch the user token
                headers.Add("Authorization", "Bearer " + App.UserSession.Token);

                // Set paraeters
                string[] parameters = { id.ToString() };

                // Check it in the data base
                await App.WsHost.ExecutePut("todos", "check", headers, null, parameters);

                // Switch the boolean attribute of Done
                item.Done = !item.Done;
                CurrentItems[CurrentItems.IndexOf(item)] = item;
            });

            _addItem = new Xamarin.Forms.Command(async () =>
            {
                // Set the header
                IDictionary<string, string> headers = new Dictionary<string, string>();
                // Fetch the user token
                headers.Add("Authorization", "Bearer " + App.UserSession.Token);

                // define the body
                string body = " { \"name\": \"" + FormTitle + "\",\"todolistId\": \"" + CurrentTodolist.Id + "\" } ";

                // Check it in the data base
                await App.WsHost.ExecutePost("todos", "add", headers, body);

                // Add to the current item
                CurrentItems.Add(new Item
                {
                    ItemTitle = FormTitle
                });

                // Empty the form
                FormTitle = string.Empty;
            });

            // Fetch all the todolists
            FetchTodolist();
        }

        // Get all todo lists
        public async void FetchTodolist()
        {
            // Set the header
            IDictionary<string, string> headers = new Dictionary<string, string>();

            // Fetch the user token
            headers.Add("Authorization", "Bearer " + App.UserSession.Token);

            // Request the server
            Todolists = await App.WsHost.ExecuteGet<ObservableCollection<Todolist>>("todolists", null, headers);

            CurrentItems = new ObservableCollection<Item>();
            _currentTodolist = new Todolist();

            // Set the first todolist's items a the current items
            CurrentTodolist = Todolists[0];

            CurrentItems = CurrentTodolist.Items;

        }
    }
}
