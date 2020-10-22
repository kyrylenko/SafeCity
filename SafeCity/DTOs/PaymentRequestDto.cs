namespace SafeCity.DTOs
{
    public class PaymentRequestDto
    {
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
