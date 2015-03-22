using UnityEngine;
using System.Collections;

[System.Serializable]public class Item 

{
    public int itemID;
    public string itemName;
    public Texture2D itemIcon;
    public ItemType itemType;
    public enum ItemType // Enum for selecint type of Item
    {
        Key, // Keys are items needed for progress
        Prop // Props are items with no clear purpose, flavour and fun
    }

    public Item(string name, int id, ItemType type)
    {
        itemID = id;
        itemName = name;
        itemType = type;
        itemIcon = Resources.Load<Texture2D>(name);
    }
    public Item()
    {
        itemID = -1;
    }




}
