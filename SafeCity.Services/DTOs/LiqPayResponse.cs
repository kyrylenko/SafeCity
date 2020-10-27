using Newtonsoft.Json;

namespace SafeCity.Services.DTOs
{
    public class LiqPayResponse
    {
        /// <summary>
        /// error	Failed payment. Data is incorrect
        /// failure	Failed payment
        /// reversed	Payment refunded
        /// subscribed	Subscribed successfully framed
        /// success	Successful payment
        /// unsubscribed	Subscribed successfully deactivated
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Transaction type. Possible values: pay - payment, hold - amount of hold on sender's account, paysplit - splitting payments, subscribe - creation of a regular payment, paydonate - donation, auth - card preauth, regular - regular payment
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }
        /// <summary>
        /// Methods of payment. Possible values card - card payment, liqpay - with liqpay account, privat24 - with privat24 account, masterpass - with masterpass account, moment_part - installments, cash - cash, invoice - to email, qr - qr code scanning.
        /// </summary>
        [JsonProperty("paytype")]
        public string PayType { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("sender_last_name")]
        public string Email { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("receiver_commission")]
        public decimal ReceiverCommission { get; set; }
        [JsonProperty("product_name")]
        public string ProjectId { get; set; }
        [JsonProperty("create_date")]
        public long CreateDate { get; set; }
        [JsonProperty("transaction_id")]
        public int TransactionId { get; set; }
    }

}
