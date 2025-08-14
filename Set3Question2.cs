namespace problemSolving
{

    public class Set3Question2
    {

        public static void Run()
        {
            Console.WriteLine("\nQuestion 2 -----> Multi-Level Nested Join with Filtering\n");
            var products = new List<Product>
            {
                new Product { Id = 1, Category = "Electronics", Price = 899.99m }, // Laptop
                new Product { Id = 2, Category = "Electronics", Price = 59.99m  }, // Mouse
                new Product { Id = 3, Category = "Electronics", Price = 299.00m }, // Monitor
                new Product { Id = 4, Category = "Books",       Price = 24.50m  },
                new Product { Id = 5, Category = "Clothing",    Price = 49.90m  },
                new Product { Id = 6, Category = "Home",        Price = 199.00m },
                new Product { Id = 7, Category = "Groceries",   Price = 5.25m   },
            };
 

        var customers = new List<Customer>
        {
            new Customer
            {
                Id = 1, Name = "Masa",
                Orders =
                {
                    new Order
                    {
                        Id = 101,
                        Items =
                        {
                            new OrderItem { ProductId = 1, Quantity = 1 }, // Laptop (Electronics)
                            new OrderItem { ProductId = 2, Quantity = 2 }, // Mouse  (Electronics)
                            new OrderItem { ProductId = 4, Quantity = 1 }, // Book
                        }
                    },
                    new Order
                    {
                        Id = 102,
                        Items =
                        {
                            new OrderItem { ProductId = 3, Quantity = 1 }, // Monitor (Electronics)
                            new OrderItem { ProductId = 7, Quantity = 6 }, // Groceries
                        }
                    }
                }
            },

            new Customer
            {
                Id = 2, Name = "Ali",
                Orders =
                {
                    new Order
                    {
                        Id = 201,
                        Items =
                        {
                            new OrderItem { ProductId = 2, Quantity = 1 }, // Mouse (Electronics)
                            new OrderItem { ProductId = 5, Quantity = 3 }, // Clothing
                        }
                    },
                    new Order
                    {
                        Id = 202,
                        Items =
                        {
                            new OrderItem { ProductId = 4, Quantity = 2 }, // Books
                            new OrderItem { ProductId = 6, Quantity = 1 }, // Home
                        }
                    }
                }
            },

            new Customer
            {
                Id = 3, Name = "Haya",
                Orders =
                {
                    new Order
                    {
                        Id = 301,
                        Items =
                        {
                            new OrderItem { ProductId = 1, Quantity = 1 }, // Laptop (Electronics)
                            new OrderItem { ProductId = 3, Quantity = 2 }, // Monitor (Electronics)
                        }
                    }
                }
            },
            new Customer{
                Id= 4,
                Name = "Charlie",
                Orders = new List<Order>()
            }

        };
            var result = (from c in customers   
                    let totalSpent = (from o in c.Orders
                    from i in o.Items
                    join product in products
                    on i.ProductId equals product.Id
                    where product.Category == "Electronics"
                    select i.Quantity * product.Price).Sum()
                    where  totalSpent > 0
                    orderby totalSpent descending
                    select new{
                        customerName = c.Name,
                        total = totalSpent
                     }).ToList();
           
            foreach(var res in result){
                Console.WriteLine(res);
            }
            


        }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public List<Order> Orders { get; set; } = new();   // init to avoid nulls
        }
        public class Order
        {
            public int Id { get; set; }
            public List<OrderItem> Items { get; set; } = new(); // init to avoid nulls
        }
        public class OrderItem
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
        public class Product
        {
            public int Id { get; set; }
            public string Category { get; set; } = "";
            public decimal Price { get; set; }
        }

        
            
    }
}