public class PaintProduct : IBuyable
{
    // Default discount: 5%
    public const decimal DefaultDiscount = 0.05m;

    // Tax rate: 10%
    public readonly decimal TaxRate;

    public int ProductId { get; set; }

    // Properties
    public string Name { get; set; }

    public PaintType Type { get; set; }

    public PaintSpecification Specification { get; set; }

    public decimal Price { get; set; }

    // Constructor
    public PaintProduct(
        string name,
        PaintType type,
        PaintSpecification specification,
        decimal price)
    {
        Name = name;
        Type = type;
        Specification = specification;
        Price = price;
        TaxRate = 0.10m;
    }

    // Calculate final price after discount and tax
    public decimal GetFinalPrice()
    {
        decimal discountedPrice = Price * (1 - DefaultDiscount);

        decimal finalPrice = discountedPrice * (1 + TaxRate);

        return finalPrice;
    }

    // Display all product information
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Type: {Type}");

        Specification.DisplaySpecification();

        Console.WriteLine($"Original Price: ${Price:F2}");
        Console.WriteLine($"Final Price: ${GetFinalPrice():F2}");
    }

    // Calculate the applicable discount rate
    public decimal GetMaxDiscount(int rate, bool isOverridable)
    {
        if (isOverridable)
        {
            return rate / 100m;
        }

        return DefaultDiscount;
    }
}