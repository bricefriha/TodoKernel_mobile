using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TodoKernel_mobile.Models
{
    public class Item
    {
        [JsonProperty("name")]
        public string Title;

        [JsonProperty("done")]
        public string Done;
    }
}
