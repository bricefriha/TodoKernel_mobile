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
        public TodolistViewModel ()
        {
            _todolists = new ObservableCollection<Todolist>();
        }

        public async void FetchTodolist()
        {
            // Set the header
            IDictionary<string, string> headers = new Dictionary<string, string>();

            // Fetch the user token
            headers.Add("Authorization", "Bearer " + App.userSession.Token);

            // Request the server
            Todolists = await App.WsHost.ExecuteGet<ObservableCollection<Todolist>>("todolists", null, headers);
        }
    }// 0143631515
}
