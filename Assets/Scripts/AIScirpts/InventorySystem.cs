using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int capacity = 30;
    public List<ItemInstance> items = new List<ItemInstance>();

    public bool AddItem(ItemData data)
    {
        if (items.Count >= capacity) return false;
        items.Add(new ItemInstance(data));
        return true;
    }

    public bool RemoveItem(ItemInstance instance)
    {
        return items.Remove(instance);
    }

    public ItemInstance FindById(string id)
    {
        return items.Find(i => i.data != null && i.data.id == id);
    }
}
