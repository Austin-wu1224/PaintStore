public class User
{
    public int UsedrId { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
    public List<Payment> Payments { get; set; }
    public User(int userId, string name)
    {
        UsedrId = userId;
        Name = name;
        Orders = new List<Order>();
        Payments = new List<Payment>();
    }
    public Order? GetMostExpersiveOrder()
    {
        return Orders
            .OrderByDescending(o => o.TotalPrice)
            .FirstOrDefault();
    }
    public Order? GetLastOrder()
    {
        return Orders
            .OrderByDescending(o => o.CreatedAt)
            .FirstOrDefault();
    }
    public Payment? GetLowestPayment()
    {
        return Payments
            .OrderBy(p => p.PaymentAmount)
            .FirstOrDefault();
    }
    public Payment? GetLastPayment()
    {
        return Payments
            .OrderByDescending(p => p.CreatedAt)
            .FirstOrDefault();
    }

    public List<Payment> GetPaymentsAbove10()
    {
        return Payments
            .Where(p => p.PaymentAmount > 10m)
            .ToList();
    }   
}