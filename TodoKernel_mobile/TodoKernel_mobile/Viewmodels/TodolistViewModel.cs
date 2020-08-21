using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using TodoKernel_mobile.Models;
using TodoKernel_mobile.Views;
using Xamarin.Essentials;

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
        }private Xamarin.Forms.Command _signout;
        public Xamarin.Forms.Command Signout
        {

            get
            {
                return _signout;
            }
        }
        private Xamarin.Forms.Command _deleteItem;
        public Xamarin.Forms.Command DeleteItem
        {

            get
            {
                return _deleteItem;
            }
        }
        private Xamarin.Forms.Command _addTodolist;
        public Xamarin.Forms.Command AddTodolist
        {

            get
            {
                return _addTodolist;
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
                var item = await App.WsHost.ExecutePost<Item>("todos", "add", headers, body);

                // Add to the current item
                CurrentItems.Add(new Item
                {
                    ItemTitle = item.ItemTitle,
                    Id = item.Id
                });

                // Empty the form
                FormTitle = string.Empty;
            });
            _signout = new Xamarin.Forms.Command( () =>
            {
                try
                {
                    // Remove the stored token
                    SecureStorage.Remove("oauth_token");

                    // Move to the sign in page
                    App.Current.MainPage = new SignInPage();
                } 
                catch (Exception ex)
                {
                    throw new Exception("Signout process: " + ex.Message);
                }
            });

            _deleteItem = new Xamarin.Forms.Command(async (id) =>
               {
                   try
                   {
                       //Item item = new Item();
                       // Get the selected item
                       //    item = (from itm in CurrentItems
                       //            where itm.Id == id.ToString()
                       //            select itm)
                       //.FirstOrDefault<Item>();//CurrentItems.Where<Item>(item => item.Id == id.ToString()).FirstOrDefault();

                       //    int itemIndex = CurrentItems.IndexOf(item);


                       // Set the header
                       IDictionary<string, string> headers = new Dictionary<string, string>();
                       // Fetch the user token
                       headers.Add("Authorization", "Bearer " + App.UserSession.Token);

                       // Set paraeters
                       string[] parameters = { id.ToString() };


                       // Check it in the data base
                       await App.WsHost.ExecuteDelete("todos", null, headers, null, parameters);

                       // ToDo: I'm reloading everery data but it's not a good things performance wise. 
                       //       I can't remove the item directely form the list because SwipeView is boken
                       //
                       // define the body
                       string body = " { \"todolistId\": \"" + CurrentTodolist.Id + "\" } ";

                       // Reload data
                       CurrentItems = await App.WsHost.ExecuteGet<ObservableCollection<Item>>("todos", "get", headers, body);

                       // Remove the item from the list
                       //CurrentItems.Remove(item);

                   }
                   catch(Exception ex)
                   {
                       throw new Exception(ex.Message);
                   }

               });

                _addTodolist = new Xamarin.Forms.Command(async () =>
               {
                   try
                   {
                       // Set the header
                       IDictionary<string, string> headers = new Dictionary<string, string>();
                       // Fetch the user token
                       headers.Add("Authorization", "Bearer " + App.UserSession.Token);

                       // define the body
                       string body = " { \"title\": \"" + FormTitle + "\" } ";

                       // Check it in the data base
                       var todolist = await App.WsHost.ExecutePost<Todolist>("todolists", "create", headers, body);

                       // Add to the current item
                       Todolists.Add(new Todolist
                       {
                           Title = todolist.Title,
                           Id = todolist.Id
                       });

                       // Empty the form
                       FormTitle = string.Empty;

                       UpdateCurrentTodolist(Todolists.Last());

                   }
                   catch(Exception ex)
                   {
                       throw new Exception(ex.Message);
                   }

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

            _currentItems = new ObservableCollection<Item>();
            _currentTodolist = new Todolist();

            // Set the first todolist's items a the current items
            UpdateCurrentTodolist(Todolists[0]);

        }
        /// <summary>
        /// Select another todolist
        /// </summary>
        /// <param name="newTodolist"></param>
        private void UpdateCurrentTodolist(Todolist newTodolist)
        {
            CurrentTodolist = newTodolist;

            CurrentItems = CurrentTodolist.Items;
        }
    }
}
