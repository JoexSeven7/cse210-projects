using System;

class Program
{
    static void Main(string[] args)
    {
       

 
        // Create addresses
        Address address1 = new Address("123 Main St", "Provo", "Utah", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "Ontario", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Jane Doe", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget A", "W001", 10.00m, 2));
        order1.AddProduct(new Product("Widget B", "W002", 15.50m, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Gadget X", "G100", 25.00m, 3));
        order2.AddProduct(new Product("Gadget Y", "G101", 10.00m, 2));
        order2.AddProduct(new Product("Tool Z", "T001", 50.00m, 1));

        // Display Order 1
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalPrice():F2}");
        Console.WriteLine();

        // Display Order 2
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalPrice():F2}");
    }
}

