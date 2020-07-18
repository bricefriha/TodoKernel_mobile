using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoKernel_mobile.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
