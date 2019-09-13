using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Inventory", menuName = "Elias/Item Inventory")]
public class ItemInventory : ScriptableObject
{
    public List<GameItem> itemsInInventory = new List<GameItem>();
    public void DeleteFromInv(GameItem Item)
    {
        itemsInInventory.Remove(Item);
    }
}
