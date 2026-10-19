// Create paint specification
PaintSpecification spec = new PaintSpecification("White", 10);

// Create paint product
PaintProduct paint = new PaintProduct(
    "White Paint",
    PaintType.BaseCoat,
    spec,
    100m
);

PaintSpecification spec2 = new PaintSpecification("Black", 5);
PaintProduct paint2 = new PaintProduct(
    "Black Paint",
    PaintType.Matte,
    spec2,
    80m
);

// Display product information
Console.WriteLine("===== Available Paints =====");

paint.DisplayInfo();

Console.WriteLine();

paint2.DisplayInfo();

// Test discount method
Console.WriteLine();

Console.WriteLine("===== Discount Test =====");

Console.WriteLine($"Override allowed: {paint.GetMaxDiscount(20, true):P0}");

Console.WriteLine($"Override not allowed: {paint.GetMaxDiscount(20, false):P0}");

Order order = new Order(paint, 2);

order.DisplayOrder();