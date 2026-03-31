public class Order
{
    private List<Product> _products;
    private Customer _customer;


    public Order (Customer customer)

    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct (Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal productTotal = 0;
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"Name: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}