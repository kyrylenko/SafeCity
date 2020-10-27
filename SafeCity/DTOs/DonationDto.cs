using System;

namespace SafeCity.DTOs
{
    public class DonationDto
    {
        public string Id { get; set; }
        public int ProjectId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string DonatedBy { get; set; }
        public DateTime Date { get; set; }
    }
}
