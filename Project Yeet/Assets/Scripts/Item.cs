using System.Collections;
using System.Collections.Generic;

public class Item
{
    private string name;
    private Dictionary<string, bool> upgrades;
    private bool equipped;
    private bool inInventory;

    public Item(string n, Dictionary<string, bool> up, bool eq, bool inIn)
    {
        this.name = n;
        this.upgrades = up;
        this.equipped = eq;
        this.inInventory = inIn;
    }

    public string getName()
    {
        return this.name;
    }

    public Dictionary<string, bool> getUpgrades()
    {
        return this.upgrades;
    }

    public bool isEquipped()
    {
        return this.equipped;
    }
    public bool isInInventory()
    {
        return this.inInventory;
    }

    public void setEquipped(bool eq)
    {
        this.equipped = eq;
    }
    public void setInInventory(bool isIn)
    {
        this.equipped = isIn;
    }

}
