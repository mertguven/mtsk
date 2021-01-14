using System;
using Newtonsoft.Json;

namespace mtsk.Models.Responses
{
    public class GetUserInformationResponseMessage
    {
        [JsonProperty("success")]
        public int success { get; set; }
        [JsonProperty("data")]
        public Data data { get; set; }
    }

    public class Data
    {
        [JsonProperty("userID")]
        public int userID { get; set; }
        [JsonProperty("userName")]
        public string userName { get; set; }
        [JsonProperty("userSurname")]
        public string userSurname { get; set; }
        [JsonProperty("userEmail")]
        public string userEmail { get; set; }
        [JsonProperty("userTelephone")]
        public string userTelephone { get; set; }
        [JsonProperty("userTC")]
        public string userTC { get; set; }
        [JsonProperty("userGender")]
        public string userGender { get; set; }
        [JsonProperty("userPassword")]
        public string userPassword { get; set; }
        [JsonProperty("userActive")]
        public int userActive { get; set; }
    }
}
