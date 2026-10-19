public class Order
{
    public DateTime CreatedAt { get;}
    public PaintProduct Product { get; set;}
    public int Quantity { get; set;}
    public decimal TotalPrice { get; set;}

    public Order(PaintProduct product, int quantity)
    {
        Product = product;
        Quantity = quantity;
        CreatedAt = DateTime.Now;
        TotalPrice = GetFinalPrice();
    }
    public decimal GetFinalPrice()
    {
        return Product.GetFinalPrice() * Quantity;
    }

    public void DisplayOrder()
{
    Console.WriteLine("===== Order Details =====");
    Console.WriteLine($"Product: {Product.Name}");
    Console.WriteLine($"Quantity: {Quantity}");
    Console.WriteLine($"Unit Price: ${Product.GetFinalPrice():F2}");
    Console.WriteLine($"Total Price: ${TotalPrice:F2}");
    Console.WriteLine($"Created At: {CreatedAt:yyyy-MM-dd HH:mm:ss}");
}
}
