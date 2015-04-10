using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour  // The database containing all the items. 
{
	public List<Item> items; //= new List<Item>();
	
	void Start()  // adding some items to the cause. 
	{
		// items.Add(new Item("Scissor", 1, Item.ItemType.Key));
		// items.Add(new Item("Stone", 1, Item.ItemType.Key));
		// items.Add(new Item("Gurka", 2, Item.ItemType.Prop));	
	}
}