using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventSystem 
{
    public static ItemEquipEvent itemEquipped = new ItemEquipEvent();
    public static ShopOpenEvent shopOpened = new ShopOpenEvent();
    public static ItemPurchaseEvent itemPurchased = new ItemPurchaseEvent();
    public static UnityEvent rewinded = new UnityEvent();
}
public class ItemEquipEvent : UnityEvent<EquipmentObject> { }
public class ShopOpenEvent : UnityEvent<ShopInventory> { }
public class ItemPurchaseEvent : UnityEvent<ShopItem> { }

