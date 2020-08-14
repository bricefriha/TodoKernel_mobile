using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace TodoKernel_mobile.Models
{
    public class Todolist
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("order")]
        public string Order { get; set; }
        [JsonProperty("items")]
        public ObservableCollection<Item> Items { get; set; }
    }
}
