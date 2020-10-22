using Newtonsoft.Json;

namespace SafeCity.Services.DTOs
{
    public class LiqPayRequest
    {
        [JsonProperty("version")] 
        public int Version { get; set; } = 3;
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
        //[JsonProperty("paytypes")]
        //[System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter))]
        //public LiqPayRequestPayType? PayTypes { get; set; }
        [JsonProperty("action")] 
        public string Action { get; set; } = "paydonate"; // or subscribe
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")] 
        public string Currency { get; set; } = "UAH";
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// Store Payer(user) email here
        /// </summary>
        [JsonProperty("sender_last_name")]
        public string Email { get; set; }
        /// <summary>
        /// Store project Id here
        /// </summary>
        [JsonProperty("product_name")]
        public string ProjectId { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; } = "uk";
        [JsonProperty("subscribe_periodicity")]
        public string SubscribePeriodicity { get; set; }// = "month";
        public string Subscribe { get; set; } //or 1
        [JsonProperty("subscribe_date_start")]
        public string SubscribeDateStart { get; set; }
        [JsonProperty("result_url")]
        public string ResultUrl { get; set; }
        [JsonProperty("server_url")]
        public string ServerUrl { get; set; }
    }
}
