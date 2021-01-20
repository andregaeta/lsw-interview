using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemSlot> m_Items = new List<ItemSlot>();
    public int m_Cash;
    public void AddItem(ItemObject item)
    {
        foreach (ItemSlot slot in m_Items)
        {
            if (slot.m_Item == item)
            {
                slot.m_Amount++;
                return;
            }
        }
        m_Items.Add(new ItemSlot(item, 1));
    }
    public void ClearItems()
    {
        m_Items.Clear();
    }
}
public class ItemSlot
{
    public ItemObject m_Item;
    public int m_Amount;
    public ItemSlot(ItemObject item, int amount)
    {
        this.m_Item = item;
        this.m_Amount = amount;
    }
}