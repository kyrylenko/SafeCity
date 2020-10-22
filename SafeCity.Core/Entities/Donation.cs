using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeCity.Core.Entities
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectId { get; set; }
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
        public string Status { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
