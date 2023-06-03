using System.Collections.ObjectModel;
using Utils;

namespace InventoryManagement;

class Inventory
{
    private static Inventory? _instance = null;

    private List<Item> _items;
    private int _maxCapacity;

    public ReadOnlyCollection<Item> Items
    {
        get { return _items.AsReadOnly(); }
    }
    public int MaxCapacity
    {
        get { return _maxCapacity; }
    }

    public Inventory(int maxCapacity)
    {
        if (_instance != null) throw new Exception("Only 1 instance of Inventory is allowed.");
        _maxCapacity = maxCapacity;
        _items = new List<Item>();

        _instance = this;
    }

    ~Inventory()
    {
        Console.WriteLine("Inventory instance destroyed.");
    }

    public bool AddItem(Item item, int quantity)
    {
        if (GetCapacity() + quantity > _maxCapacity) return false;
        if (_items.Any(listItem => listItem.Barcode == item.Barcode)) return false;
        item.IncreaseQuantity(quantity);
        _items.Add(item);

        return true;
    }

    public bool RemoveItem(string barcode)
    {
        Item? item = _items.Find(listItem => listItem.Barcode == barcode);
        if (item == null) return false;
        _items.Remove(item);

        return true;
    }

    public bool IncreaseQuantity(string barcode, int change)
    {
        if (GetCapacity() + change > _maxCapacity) return false;
        Item? item = _items.Find(listItem => listItem.Barcode == barcode);
        if (item == null) return false;
        item.IncreaseQuantity(change);

        return true;
    }

    public bool DecreaseQuantity(string barcode, int change)
    {
        Item? item = _items.Find(listItem => listItem.Barcode == barcode);
        if (item == null) return false;
        item.DecreaseQuantity(change);

        return true;
    }

    public void ViewInventory()
    {
        Printer.PrintInventory(this);
    }

    private int GetCapacity()
    {
        int capacity = 0;
        foreach (Item item in _items)
        {
            capacity += item.Quantity;
        }
        return capacity;
    }
}