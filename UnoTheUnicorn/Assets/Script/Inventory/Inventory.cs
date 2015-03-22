using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory : MonoBehaviour 
{
	public int slotsX, slotsY;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	public GUISkin invSkin;
	private ItemDataBase database;
	private bool ShowInventory;
	private bool DraggingItem;
	private Item DraggedItem;
	private int prevIndex;
	void Start () 
	{
		for (int i =0; i<(slotsX * slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		database = GameObject.FindGameObjectWithTag("ItemDB").GetComponent<ItemDataBase>();
		AddItem(0);
		AddItem(1);
		AddItem(2);
		
		
		print(InventoryContains(1)); // check if inventory slot (X) is empty or not
		print(InventoryContains(3));
	}
	
	// Update is called once per frame
	
	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			ShowInventory =! ShowInventory;
		}
	}
	
	void OnGUI ()
	{
		
		if (GUI.Button(new Rect(40, 400, 100, 40), "save"))
		{
			SaveInventory();
		}
		
		if (GUI.Button(new Rect(150, 400, 100, 40), "Load"))
		{
			LoadInventory();
		}
	
		GUI.skin = invSkin;
		if (ShowInventory)
		{
			DrawInventory();
		}
		if (DraggingItem)
		{
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y,50,50),DraggedItem.itemIcon);
		}
		
	}
	
	void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		for (int y = 0; y < slotsY; y++)
		{
			for (int x = 0; x < slotsX; x++)
			{
				Rect slotRec = new Rect(x * 50, y * 50, 40, 40);
				GUI.Box(slotRec, y.ToString(),invSkin.GetStyle("Slot"));
				slots[i] = inventory[i];
				
				if (slots[i].itemID != null)
				{
					GUI.DrawTexture(slotRec, slots[i].itemIcon);    
					if(slotRec.Contains(e.mousePosition))
						
					{	
						if (e.button == 0 && e.type == EventType.MouseDrag && !DraggingItem)
						{
							DraggingItem = true;
							prevIndex = i;
							DraggedItem = slots[i];
							inventory[i] = new Item();
						}
						if (e.type == EventType.mouseUp && DraggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = DraggedItem;
							DraggingItem = false;
							DraggedItem = null;
						}
						
					}
					else
					{
						if(slotRec.Contains(e.mousePosition))
						{
							if (e.type == EventType.mouseUp && DraggingItem)
							{
								inventory[i] = DraggedItem;
								DraggingItem = false;
								DraggedItem = null;
							}
					
						}
					}
					
					
				}

				i++;
			}
		}
	}

	void AddItem (int id)
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemName == null)
			{
				for (int j = 0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}
	
	
	void RemoveItem (int id)
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].itemID == id)
			{
				inventory[i] = new Item();
				break;
			}
		}
	}
	
	void SaveInventory()
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			PlayerPrefs.SetInt("inventory " + i, inventory[i].itemID);
		}
		
	}
	
	void LoadInventory()
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			inventory[i] = PlayerPrefs.GetInt("inventory " + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("inventory "+ i)] : new Item();
		}
		
	}
	
	
	bool InventoryContains (int id)
	{
		bool result = false;
		for (int i = 0; i < inventory.Count; i++)
		{
			result = inventory[i].itemID == id;
			if (result)
			{
				break;
			} 
		}
		return result;
	}
	
	
}
