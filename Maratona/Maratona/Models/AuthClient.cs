using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Maratona.Models
{
    public class AuthClient
    {
        public string access_token { get; set; }
        public DateTime expires_on { get; set; }
        public string provider_name { get; set; }
        public List<User_Claims> user_claims { get; set; }
        public string user_id { get; set; }
    }

    public class User_Claims
    {
        public string typ { get; set; }
        public string val { get; set; }
    }


    //public class AuthClient
    //{
    //    [JsonProperty(PropertyName = "id_token")]
    //    public string IdToken { get; set; }

    //    [JsonProperty(PropertyName = "user_id")]
    //    public string UserId { get; set; }

    //    [JsonProperty(PropertyName = "provider_name")]
    //    public string Name { get; set; }

    //    [JsonProperty(PropertyName = "user_claims")]
    //    public List<UserClaim> UserClaims { get; set; }
    //}

    //public class UserClaim
    //{
    //    [JsonProperty(PropertyName = "typ")]
    //    public string Type { get; set; }

    //    [JsonProperty(PropertyName = "val")]
    //    public string Value { get; set; }
    //}

}
