public class Product
{
   private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName() { return _name; }
    public void SetName(string value) { _name = value; }
    
    public string GetProductId() { return _productId; }
    public void SetProductId(string value) { _productId = value; }
    
    public decimal GetPrice() { return _price; }
    public void SetPrice(decimal value) { _price = value; }
    
    public int GetQuantity() { return _quantity; }
    public void SetQuantity(int value) { _quantity = value; }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}