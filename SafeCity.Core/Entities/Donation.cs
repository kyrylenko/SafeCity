using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeCity.Core.Entities
{
    public class Donation
    {
        /// <summary>
        /// Should correspond to the OrderId of liqpay payment.
        /// Structure: {DateTime.Now.Ticks}-{payment.Email}-{payment.ProjectId}
        /// </summary>
        [Key]
        public string Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public Currency Currency { get; set; } = Currency.Uah;
        public DateTime DateTime { get; set; }
        public string Source { get; set; } = "liqpay";
        /// <summary>
        /// External transaction Id, e.g. liqpay transaction_id
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// External payment status, e.g. "success"
        /// </summary>
        public PaymentAction Action { get; set; }
        public decimal ReceiverCommission { get; set; }
        public string Ip { get; set; }
        public string Status { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
