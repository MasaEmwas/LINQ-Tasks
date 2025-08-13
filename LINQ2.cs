namespace problemSolving
{

    public class Level2Examples
    {

        public static void Run()
        {

            Console.WriteLine("\nQuestion 5 - Nested Projection with SelectMany\n");

            var customers = new List<Customer>
            {
                        new Customer
                        {
                            Name = "Masa",
                            Orders = new List<Order2>
                            {
                                new Order2 { OrderId = 101, Total = 250.00m },
                                new Order2 { OrderId = 102, Total = 99.99m }
                            }
                        },
                        new Customer
                        {
                            Name = "Ali",
                            Orders = new List<Order2>
                            {
                                new Order2 { OrderId = 201, Total = 300.00m }
                            }
                        },
                        new Customer
                        {
                            Name = "Haya",
                            Orders = new List<Order2>() // no orders yet
                        }
            };

            var customerResult = customers
                                .SelectMany(
                                    c => c.Orders,
                                    (c, o) => new
                                    {
                                        CustomerName = c.Name,
                                        Order2Id = o.OrderId,
                                        Total2 = o.Total
                                    }
                                ).ToList();

            var customerResult2 =
                        (from c in customers
                        from o in c.Orders      // second from = SelectMany (flatten)
                        select new
                        {
                            CustomerName = c.Name,
                            Order2Id = o.OrderId,
                            Total2 = o.Total
                        }).ToList();

                Console.WriteLine("Flattened Orders:");
                foreach (var x in customerResult2)
                        {
                            Console.WriteLine(x);
                        }

            Console.WriteLine("\nQuestion 6 - Conditional Group Aggregation\n");

            var sales = new List<Sale>
            {
                new Sale{ Region = "South", Amount = 1500.00m },
                new Sale{ Region = "North", Amount = 100.00m  },
                new Sale{ Region = "North", Amount = 2500.00m},
                new Sale{ Region = "East", Amount = 900.00m}
            };

            var salesResult = (from sale in sales
                            group sale by sale.Region into g
                            select new
                            {
                                region = g.Key,
                                totalSales = g.Sum(x => x.Amount),
                                averageSales = g.Average(x => x.Amount),
                                highValueSales = g.Where(x => x.Amount > 1000).Count()

                            }).ToList();


            foreach (var result in salesResult)
            {
                Console.WriteLine(result);
            }

            Console.WriteLine("\nQuestion 7 - Join + GroupBy + Aggregation\n");

            var products = new List<Product>
            {
                new Product { Id = 1, Category = "Electronics" },
                new Product { Id = 2, Category = "Clothing" },
                new Product { Id = 3, Category = "Books" },
                new Product { Id = 4, Category = "Groceries" },
                new Product { Id = 5, Category = "Toys" }
            };

            var orders = new List<Order3>
            {
                new Order3 { ProductId = 1, Quantity = 5 },
                new Order3 { ProductId = 2, Quantity = 2 },
                new Order3 { ProductId = 3, Quantity = 7 },
                new Order3 { ProductId = 1, Quantity = 3 },
                new Order3 { ProductId = 4, Quantity = 4 },
                new Order3 { ProductId = 5, Quantity = 1 },
                new Order3 { ProductId = 3, Quantity = 2 },
            };

            var orderProductResult = (from o in orders
                                    join product in products
                                    on o.ProductId equals product.Id
                                    group o by product.Category into g
                                    select new
                                    {
                                        productCategory = g.Key,
                                        orderQuantity = g.Sum(x=> x.Quantity)

                                    }).ToList();

            foreach (var result in orderProductResult)
            { 
                Console.WriteLine(result);
            }  
        }
    }
}