namespace WebApplication1.Models
{
    public class CustomerVip : Customer
    {
        public DateTime? VipExpired { get; set; }
        public decimal Discount { get; set; }
    }
}