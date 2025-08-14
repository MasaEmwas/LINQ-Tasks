namespace problemSolving
{

    public class Set3Question3
    {

        public static void Run()
        {
            Console.WriteLine("\nQuestion 3 -----> Dynamic Grouping with Sub-Aggregates\n");
            var sales = new List<Sale>
            {
                new Sale { Region = "North", CustomerId = 101, Amount = 1500 },
                new Sale { Region = "North", CustomerId = 102, Amount = 750 },
                new Sale { Region = "North", CustomerId = 103, Amount = 900 },
                new Sale { Region = "South", CustomerId = 104, Amount = 2000 },
                new Sale { Region = "South", CustomerId = 105, Amount = 500 },
                new Sale { Region = "East",  CustomerId = 106, Amount = 1200 },
                new Sale { Region = "East",  CustomerId = 107, Amount = 300 },
                new Sale { Region = "West",  CustomerId = 108, Amount = 1800 },
                new Sale { Region = "West",  CustomerId = 109, Amount = 400 }
            };
            var result = (from s in sales
                         group s by s.Region
                         into g
                         select new{
                            region = g.Key,
                            totalSales = g.Sum(x=> x.Amount),
                            numberCustomers = g.Select(x=>x.CustomerId).Distinct().Count(),
                            maxTransaction = g.Max(x => x.Amount),
                            high = g.Where(x=>x.Amount>1000).Count(),
                            low = g.Where(x=>x.Amount<=1000).Count()
                         }).ToList();

                foreach(var res in result){
                    Console.WriteLine(res);
                }
        }
        public class Sale
        {
            public string Region { get; set; }
            public int CustomerId { get; set; }
            public decimal Amount { get; set; }
        }

    }
}