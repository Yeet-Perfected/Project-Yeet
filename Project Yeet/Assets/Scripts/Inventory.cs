using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    public static Item[] inventory =
    {
        new Item("Bionic Arm", new Dictionary<string, bool>()
        {
            {"Placeholder", false}
        }, true, true),

        new Item("Bionic Eye", new Dictionary<string, bool>()
        {
            {"Placeholder", false}
        }, false, true)
    };

    public static Item getItemByName(string name)
    {
        foreach (Item item in inventory)
        {
            if (item.getName().Equals(name))
            {
                return item;
            }
        }
        return new Item("Null", new Dictionary<string, bool>(), false, false);
    }

}
