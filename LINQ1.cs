namespace problemSolving
{

    public class Level1Examples {

        public static void Run() { 

            //Question 1: Find the Strings that start with M
            Console.WriteLine("Question 1 - Find the products that start with the letter 'M'\n");
            List<string> products = ["Laptop", "Mouse", "Keyboard", "Monitor", "Speaker"];

            // Method 1: Using Query Expression 
            var result = from item in products
                        where item[0] == 'M'
                        select item;

            // Method 2: Using Method Syntax
            var result2 = products.Where(w => w.StartsWith('M'));

            //Execution of Query 
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }

        Console.WriteLine("----------------------------------------------------------->\n");


            Console.WriteLine("Question 2 - Group Orders by CustomerName and calculate the total amount spent by each customer");

            var orders = new List<Order>
            {
                new Order{ OrderId = 1, CustomerName = "Ali", Amount = 250},
                new Order{ OrderId = 2, CustomerName = "Ahmad", Amount = 150},
                new Order{ OrderId = 3, CustomerName = "Ali", Amount = 300},
                new Order{ OrderId = 4, CustomerName = "Haya", Amount = 300}
            };

        var result3 = from order in orders
                    group order by order.CustomerName;

            foreach (var res in result3)
            {
                Console.WriteLine($"Name: {res.Key}");
                foreach (var x in res)
                {
                    Console.WriteLine($"   {x.Amount}");
                }
            }

            Console.WriteLine("\n\n Total spent by Each Custmer\n");

            var total = from order in orders
                        group order by order.CustomerName into g
                        select new
                        {
                            customer_name = g.Key,
                            total_price = g.Sum(x => x.Amount)
                            
                        };


            foreach (var x in total)
            {
                Console.WriteLine(x);
                Console.WriteLine($"Customer: {x.customer_name}    ---->     TotalPrice: {x.total_price}\n");
            }

            Console.WriteLine("----------------------------------------------------------->\n");
            Console.WriteLine("Question 3 -  Group employees by Salary, in each group order alphabetically, Select groups that have more than 2 employees");

            var employee = new List<Employee>
            {
                new Employee{ Id = 1, Name = "Masa", Salary = 4500 },
                new Employee{ Id = 2, Name = "Abdulla", Salary = 2000},
                new Employee{ Id = 3, Name = "Ehab", Salary = 2000},
                new Employee{ Id = 4, Name = "Areen", Salary = 4500},
                new Employee{ Id = 5, Name = "Sarah", Salary = 5000},
                new Employee{ Id = 6, Name = "Worood", Salary = 4500},
                new Employee{ Id = 7, Name = "Nidal", Salary = 2000}
            };

            var employeeResult = employee
                                .GroupBy(x => x.Salary);

            var employeeResult2 = from em in employee
                                group em by em.Salary;
            foreach (var x in employeeResult)
            {
                Console.WriteLine(x.Key);
                foreach (var i in x)
                {
                    Console.WriteLine($"       {i.Name}");
                }
            }


            var employeeResult3 = (from emp in employee
                                group emp by emp.Salary into g
                                where g.Count() > 2
                                select new {
                                    salary = g.Key,
                                    EmployeeName = string.Join(", ", g.OrderBy(e => e.Name).Select(n=>n.Name))
                                }).ToList();
            Console.WriteLine("---------->\nThe Results are: \n");

            foreach (var empl in employeeResult3)
            {
                Console.WriteLine(empl);
            }

            Console.WriteLine("\nQuestion 4 - LINQ Join to return each student's name along with their score\n");

            var students = new List<Student>
            {
                new Student{Id = 1, Name ="Ali"},
                new Student{Id = 2, Name ="Sara"}
            };

            var grades = new List<Grade>
            {
                new Grade {StudentId = 1, Score = 85},
                new Grade {StudentId = 2, Score = 92 }
            };
            // Method 1
            var studentResult = from student in students
                                join grade in grades
                                on student.Id equals grade.StudentId
                                select new
                                {
                                    studentName = student.Name,
                                    gradeScore = grade.Score
                                };

            foreach (var student in studentResult)
            {
                Console.WriteLine("{0}   -    {1}", student.studentName, student.gradeScore);

            }
            Console.WriteLine("\n---\n");
            // Method 2
            var studentResult2 = students.Join(grades,
                                            s => s.Id,
                                            g => g.StudentId,
                                            (newStudent, newGrade) => new
                                            {
                                                studentName = newStudent.Name,
                                                gradeScore = newGrade.Score
                                            });

            foreach (var student in studentResult2)
            {
                Console.WriteLine("{0}   -    {1}", student.studentName, student.gradeScore);

            }
        }
    }
}