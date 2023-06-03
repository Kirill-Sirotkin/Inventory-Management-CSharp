namespace InventoryManagement;

class Item
{
    private static List<string> Barcodes = new List<string>();

    private string _barcode;
    private string _name;
    private int _quantity;

    public String Barcode
    {
        get { return _barcode; }
    }
    public String Name
    {
        get { return _name; }
    }
    public int Quantity
    {
        get { return _quantity; }
    }

    public Item(string barcode, string name, int quantity)
    {
        if (Barcodes.Contains(barcode)) throw new Exception("Item with that barcode already exists");
        if (quantity < 0) throw new Exception("Quantity cannot be negative");

        _barcode = barcode;
        _name = name;
        _quantity = quantity;

        Barcodes.Add(barcode);
    }

    ~Item()
    {
        Barcodes.Remove(_barcode);
    }

    public void IncreaseQuantity(int change)
    {
        if (change < 0) throw new Exception("Quantity change value cannot be negative");
        _quantity += change;
    }

    public void DecreaseQuantity(int change)
    {
        if (change < 0) throw new Exception("Quantity change value cannot be negative");
        if (_quantity - change < 0) throw new Exception("Quantity cannot be negative");
        _quantity -= change;
    }
}