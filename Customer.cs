public class Customer
{
    public string Name { get; set; } = "";
    public List<Order2> Orders { get; set; } = new(); // init so it's never null
}
