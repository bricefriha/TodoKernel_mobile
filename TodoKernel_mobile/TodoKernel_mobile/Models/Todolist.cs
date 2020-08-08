using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TodoKernel_mobile.Models
{
    public class Todolist
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("order")]
        public string Order { get; set; }
    }
}
