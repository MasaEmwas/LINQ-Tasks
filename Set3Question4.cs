namespace problemSolving
{
    public class Set3Question4
    {
        public static void Run()
        {
            Console.WriteLine("\nQuestion 4 -----> Time-Series Aggregation by Month and Category\n");
            var transactions = new List<Transaction>
            {
                new Transaction { Date = new DateTime(2025, 1,  3), Category = "Groceries",   Amount = 85.50m },
                new Transaction { Date = new DateTime(2025, 1, 10), Category = "Electronics", Amount = 249.99m },
                new Transaction { Date = new DateTime(2025, 1, 15), Category = "Groceries", Amount = 60.00m },
                new Transaction { Date = new DateTime(2025, 2,  5), Category = "Electronics",   Amount = 92.75m },
                new Transaction { Date = new DateTime(2025, 2,  8), Category = "Utilities",   Amount = 110.00m },
                new Transaction { Date = new DateTime(2025, 2, 20), Category = "Electronics", Amount = 499.00m },
                new Transaction { Date = new DateTime(2025, 3,  1), Category = "Entertainment", Amount = 35.00m },
                new Transaction { Date = new DateTime(2025, 3, 12), Category = "Utilities",   Amount = 78.40m },
                new Transaction { Date = new DateTime(2025, 3, 22), Category = "Utilities",   Amount = 115.25m },
                new Transaction { Date = new DateTime(2025, 3, 28), Category = "Electronics", Amount = 120.00m },
            };

            var result = (from transaction in transactions
                         group transaction by new {transaction.Date.Month,transaction.Category} into g
                         select new {
                                month = g.Key.Month, 
                                category = g.Key.Category,
                                total = g.Sum(x=> x.Amount)
                         }).ToList(); 
            foreach(var res in result){
                Console.WriteLine(res);
            }
            Console.WriteLine("\n\n ------->");

        }
        public class Transaction
        {
            public DateTime Date { get; set; }
            public string Category { get; set; }
            public decimal Amount { get; set; }
        }
        
    }
}