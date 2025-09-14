using Hospital.Business.Core;
namespace Hospital.Business.Dtos
{
    public class PaymentCheckDto
    {
        public string Token { get; set; } = string.Empty;
        public int ReceptId { get; set; }
        public PaymentStatuses STATUS { get; set; }
    }
}
