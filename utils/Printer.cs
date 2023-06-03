using InventoryManagement;

namespace Utils;

static class Printer
{
    public static void PrintItem(Item item)
    {
        Console.WriteLine($"barcode: {item.Barcode}; name: {item.Name}; quantity: {item.Quantity}");
    }

    public static void PrintInventory(Inventory inventory)
    {
        Console.WriteLine($"Inventory contents (max capacity: {inventory.MaxCapacity}):");
        foreach (Item item in inventory.Items)
        {
            PrintItem(item);
        }
    }
}