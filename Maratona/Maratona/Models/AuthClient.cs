using Newtonsoft.Json;
using System.Collections.Generic;

namespace Maratona.Models
{
    public class AuthClient
    {
        [JsonProperty(PropertyName = "id_token")]
        public string IdToken { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "provider_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "user_claims")]
        public List<UserClaim> UserClaims { get; set; }
    }

    public class UserClaim
    {
        [JsonProperty(PropertyName = "typ")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "val")]
        public string Value { get; set; }
    }
}
