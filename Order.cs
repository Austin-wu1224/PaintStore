public class Order
{
    public DateTime CreatedAt { get;}
    public PaintProduct Product { get; set;}
    public int Quantity { get; set;}
    public decimal TotalPrice { get; set;}
    public List<PaintProduct> PaintProducts { get; set;}

    public Order(PaintProduct product, int quantity)
    {
        Product = product;
        Quantity = quantity;
        CreatedAt = DateTime.Now;
        TotalPrice = GetFinalPrice();
        PaintProducts = new List<PaintProduct>();
        PaintProducts.Add(product);
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

    public PaintProduct? GetMostExpensivePaintProduct()
     {
            return PaintProducts
                 .OrderByDescending(p => p.Price)
                .FirstOrDefault();
     }
     public void RemoveProduct(int productId)
    {
        PaintProducts.RemoveAll(p => p.ProductId == productId);
    }
    public List<PaintProduct> GetProductsByPriceRange(decimal x, decimal y)
    {
        return PaintProducts
            .Where(p => p.Price > x && p.Price < y)
            .ToList();
    }
    public Dictionary<PaintType, decimal> GetTotalPriceByPaintType()
    {
        return PaintProducts
            .GroupBy(p => p.Type)
            .ToDictionary(
                group => group.Key,
                group => group.Sum(p => p.Price)
                );
    }
}
