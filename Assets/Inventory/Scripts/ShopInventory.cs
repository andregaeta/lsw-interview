using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Inventory", menuName = "Shop Inventory")]
public class ShopInventory : ScriptableObject
{
    public List<ShopItem> m_Items = new List<ShopItem>();
}

[System.Serializable]
public class ShopItem
{
    public EquipmentObject m_Item;
    public bool m_Purchased;
    public int m_Price;
}