namespace Src.LINQ;

class MyLINQ
{
    public static void Run()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        foreach (var n in evenNumbers)
        {
            System.Console.WriteLine(n);
        }

        /// Linq
        /// Select and Where
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Price = 1.2 },
            new Product { Id = 2, Name = "Banana", Price = 0.5 },
            new Product { Id = 3, Name = "Cherry", Price = 2.0 }
        };

        var cheapProducts = products
            .Where(p => p.Price < 1.0)
            .Select(p => new { p.Name, p.Price }).ToList();

        foreach (var cproduct in cheapProducts)
        {
            Console.WriteLine($"{cproduct.Name}: {cproduct.Price}");
        }

        // 在 LINQ 中，查询是延迟执行的，除非使用像 ToList() 这样的终结方法，否则查询不会立即执行。
        var aync_numbers = new List<int> { 1, 2, 3, 4, 5 };

        // 延迟执行：query 还没有执行
        var query = aync_numbers.Where(n => n > 3);

        // 立即执行：结果被存储在列表中
        var resultList = query.ToList();

        foreach (var number in resultList)
        {
            Console.WriteLine(number);
        }


        /// GroupBy
        var orders = new List<Order>
        {
            new Order { CustomerId = 1, ProductName = "Apple", Quantity = 10 },
            new Order { CustomerId = 1, ProductName = "Banana", Quantity = 5 },
            new Order { CustomerId = 2, ProductName = "Cherry", Quantity = 20 }
        };

        var ordersByCustomer = orders
            .GroupBy(o => o.CustomerId)
            .Select(g => new { CustomerId = g.Key, Orders = g.ToList() });

        foreach (var group in ordersByCustomer)
        {
            Console.WriteLine($"Customer {group.CustomerId}:");
            foreach (var order in group.Orders)
            {
                Console.WriteLine($"  {order.ProductName}: {order.Quantity}");
            }
        }

        /// Join
        var customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John" },
            new Customer { Id = 2, Name = "Jane" }
        };

        orders = new List<Order>
        {
            new Order { CustomerId = 1, ProductName = "Apple", Quantity = 10 },
            new Order { CustomerId = 2, ProductName = "Banana", Quantity = 5 }
        };

        var customerOrders = customers
            .Join(orders,
                customer => customer.Id,
                order => order.CustomerId,
                (customer, order) => new { customer.Name, order.ProductName, order.Quantity });

        foreach (var co in customerOrders)
        {
            Console.WriteLine($"{co.Name} ordered {co.ProductName}: {co.Quantity}");
        }

        /// zip
        var numbers_int = new List<int> { 1, 2, 3 };
        var words = new List<string> { "One", "Two", "Three" };

        var pairs = numbers_int.Zip(words, (number, word) => $"{number}: {word}");

        foreach (var pair in pairs)
        {
            Console.WriteLine(pair);
        }

        /// Aggregate
        var numbers_agg = new List<int> { 1, 2, 3, 4, 5 };

        var sum = numbers_agg.Aggregate((acc, n) => acc + n);
        Console.WriteLine($"Sum: {sum}");

        var product = numbers_agg.Aggregate(1, (acc, n) => acc * n);
        Console.WriteLine($"Product: {product}");

        /// Distinct
        var numbers_dis = new List<int> { 1, 2, 2, 3, 4, 4, 5 };

        var distinctNumbers = numbers_dis.Distinct();

        foreach (var number in distinctNumbers)
        {
            Console.WriteLine(number);
        }


        /// ToDictionary
        products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Price = 1.2 },
            new Product { Id = 2, Name = "Banana", Price = 0.5 },
            new Product { Id = 3, Name = "Cherry", Price = 2.0 }
        };

        var productDictionary = products.ToDictionary(p => p.Id, p => p.Name);

        foreach (var kvp in productDictionary)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}

internal class Customer
{
    public int Id { get; set; }
    public string? Name { get; set;}
}

internal class Order
{
    public int CustomerId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set;}
}

internal class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
}