public class Payment
{
    public int PaymentId { get; set; }
    public DateTime CreatedAt { get;}
    public PaymentStatus Status { get; set; }
    public decimal PaymentAmount { get; set; }
    public PaymentMethod Method { get; set; }
    public Order Order { get; set; }
    public User User { get; set; }
    public Payment(int paymentId, Order order, User user, PaymentMethod method)
    {
        PaymentId = paymentId;
        Order = order;
        User = user;
        Method = method;
        PaymentAmount = order.TotalPrice;
        Status = PaymentStatus.Pending;
        CreatedAt = DateTime.Now;
    }
}