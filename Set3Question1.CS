namespace problemSolving
{

    public class Set3Question1
    {

        public static void Run()
        {

            Console.WriteLine("Question 1 -----> Multi-Level Join with Grouping and Conditional Aggregation\n");
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Books" },
                new Category { Id = 4, Name = "Groceries" }
            };
            var products = new List<Product>
            {
            new Product { Id = 101, CategoryId = 1 }, // Electronics
            new Product { Id = 102, CategoryId = 1 }, // Electronics
            new Product { Id = 103, CategoryId = 2 }, // Clothing
            new Product { Id = 104, CategoryId = 3 }, // Books
            new Product { Id = 105, CategoryId = 4 }  // Groceries
            };

            var orders = new List<Order>
            {
                new Order { ProductId = 101, Quantity = 5 }, // Electronics
                new Order { ProductId = 102, Quantity = 3 },
                new Order { ProductId = 103, Quantity = 2 },
                new Order { ProductId = 104, Quantity = 7 },
                new Order { ProductId = 105, Quantity = 4 },
                new Order { ProductId = 101, Quantity = 9 }
            };

            var result = (from order in orders
                          join product in products
                             on order.ProductId equals product.Id
                          join category in categories
                             on product.CategoryId equals category.Id
                          group order by category.Name into g
                          where g.Sum(x => x.Quantity) > 10
                          select new
                          {

                              categoryName = g.Key,
                              orderQuantity = g.Sum(x => x.Quantity)
                          }).ToList();

            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }


        public class Order
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
        public class Product
        {
            public int Id { get; set; }
            public int CategoryId { get; set; }
        }
        public class Category
        {
            public int Id { get; set; }
            public string Name = "";
        }

    }

}