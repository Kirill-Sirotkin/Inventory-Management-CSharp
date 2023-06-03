using InventoryManagement;

internal class Program
{
    private static void Main(string[] args)
    {
        Item item1 = new Item("1", "apple");
        // Item item1_1 = new Item("1", "pear"); // --- throws error since this barcode exists.
        Item item2 = new Item("2", "orange");
        Item item3 = new Item("3", "tomato");

        Inventory inventory = new Inventory(10);
        // Inventory inventory1 = new Inventory(20); // --- throws error since an inventory instance already exists.

        inventory.AddItem(item1, 3);
        inventory.AddItem(item2, 1);
        inventory.AddItem(item3, 2);

        inventory.ViewInventory();

        inventory.DecreaseQuantity("1", 2);
        inventory.IncreaseQuantity("2", 4);

        inventory.ViewInventory();
    }
}