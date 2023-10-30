using ConsoleMarket.Entities;
using System.Globalization;

Console.WriteLine("Enter cliente data:");
Console.Write("Name: ");
string name = Console.ReadLine();
Console.Write("Email: ");
string email = Console.ReadLine();
Console.Write("Birth date (DD/MM/YYYY): ");
DateTime bithDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
Client client = new Client(name, email, bithDate);

Console.WriteLine("Enter order data: ");
Console.Write("Status: ");
OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
Order order = new Order(DateTime.Now, status, client);

Console.Write("How many items to this order? ");
int quantityOrders = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < quantityOrders; i++)
{
    Console.WriteLine($"Enter #{i + 1} item data:");
    Console.Write("Product name: ");
    string productName = Console.ReadLine();
    Console.Write("Product price: ");
    double price = Convert.ToDouble(Console.ReadLine());
    Console.Write("Quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());
    Product product = new Product(productName, price); 
    
    OrderItem orderItem = new OrderItem(quantity, price, product);
    order.AddItem(orderItem);
}

Console.WriteLine();
Console.WriteLine("ORDER SUMMARY:");
Console.WriteLine(order.ToString());
