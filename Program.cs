// Create paint specification
PaintSpecification spec = new PaintSpecification("White", 10);

// Create paint product
PaintProduct paint = new PaintProduct(
    "White Paint",
    PaintType.BaseCoat,
    spec,
    100m
);
paint.ProductId = 1;

PaintSpecification spec2 = new PaintSpecification("Black", 5);
PaintProduct paint2 = new PaintProduct(
    "Black Paint",
    PaintType.Matte,
    spec2,
    80m
);
paint2.ProductId = 2;

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

order.PaintProducts.Add(paint2);
PaintProduct? mostExpensive = order.GetMostExpensivePaintProduct();
if (mostExpensive != null)
{
    Console.WriteLine($"Most Expensive Paint: {mostExpensive.Name}");
    Console.WriteLine($"Price: ${mostExpensive.Price:F2}");
}

Console.WriteLine("===== Before Remove =====");

Console.WriteLine($"Product Count: {order.PaintProducts.Count}");

order.RemoveProduct(2);

Console.WriteLine("===== After Remove =====");

Console.WriteLine($"Product Count: {order.PaintProducts.Count}");

Console.WriteLine("===== Products in Price Range =====");
List<PaintProduct> results = order.GetProductsByPriceRange(50m, 120m);
foreach (PaintProduct p in results)
{
    Console.WriteLine($"Product: {p.Name}. Price: ${p.Price:F2}");
}

order.PaintProducts.Add(paint2);
Dictionary<PaintType, decimal> totals = order.GetTotalPriceByPaintType();

Console.WriteLine("===== Total Price By Paint Type =====");

foreach (var item in totals)
{
    Console.WriteLine($"Type: {item.Key}, Total: ${item.Value:F2}");
}
User user = new User(1, "Tom");

Payment payment = new Payment(
    1001,
    order,
    user,
    PaymentMethod.CreditCard);

Console.WriteLine("===== Payment Details =====");

Console.WriteLine($"Payment ID: {payment.PaymentId}");

Console.WriteLine($"Amount: ${payment.PaymentAmount:F2}");

Console.WriteLine($"Status: {payment.Status}");

Console.WriteLine($"Method: {payment.Method}");
Console.WriteLine($"Payment User: {payment.User.Name}");
Order order2 = new Order(paint2, 3);
user.Orders.Add(order);
user.Orders.Add(order2);   
Order? mostExpensiveOrder = user.GetMostExpersiveOrder();
if (mostExpensiveOrder != null)
{
    Console.WriteLine("===== Most Expensive Order =====");
    Console.WriteLine($"Product: {mostExpensiveOrder.Product.Name}");
    Console.WriteLine($"Total Price: ${mostExpensiveOrder.TotalPrice:F2}");
}

Order? lastOrder = user.GetLastOrder();
if (lastOrder != null)
{
    Console.WriteLine("===== Last Order =====");
    Console.WriteLine($"Product: {lastOrder.Product.Name}");
    Console.WriteLine($"Created At: {lastOrder.CreatedAt:yyyy-MM-dd HH:mm:ss}");
}
Payment payment2 = new Payment(
    1002,
    order2,
    user,
    PaymentMethod.BankTransfer);
user.Payments.Add(payment);
user.Payments.Add(payment2);
Payment? lowestPayment = user.GetLowestPayment();
if (lowestPayment != null)
{
    Console.WriteLine("===== Lowest Payment =====");
    Console.WriteLine($"Payment ID: {lowestPayment.PaymentId}");
    Console.WriteLine($"Amount: ${lowestPayment.PaymentAmount:F2}");
}

Payment? lastPayment = user.GetLastPayment();

if (lastPayment != null)
{
    Console.WriteLine("===== Last Payment =====");
    Console.WriteLine($"Payment ID: {lastPayment.PaymentId}");
    Console.WriteLine($"Amount: ${lastPayment.PaymentAmount:F2}");
    Console.WriteLine($"Created At: {lastPayment.CreatedAt:yyyy-MM-dd HH:mm:ss}");
}

List<Payment> paymentsAbove10 = user.GetPaymentsAbove10();
Console.WriteLine("===== Payments Above $10 =====");
foreach (Payment p in paymentsAbove10)
{
    Console.WriteLine($"Payment ID: {p.PaymentId}, Amount: ${p.PaymentAmount:F2}");
}

