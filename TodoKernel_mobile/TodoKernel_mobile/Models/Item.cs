using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TodoKernel_mobile.Models
{
    public class Item
    {
        [JsonProperty("name")]
        public string ItemTitle { get; set; }

        [JsonProperty("done")]
        public bool Done { get; set; }
        public string CheckIcon { get; set; }
    }

}
