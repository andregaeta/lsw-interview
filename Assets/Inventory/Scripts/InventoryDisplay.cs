using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Inventory m_Inventory;
    [SerializeField] private Text m_CashText;

    private void Awake()
    {
        EventSystem.itemPurchased.AddListener(OnItemPurchased);
        EventSystem.rewinded.AddListener(OnRewind);
    }
    private void Start()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        foreach(ItemSlotDisplay slot in this.transform.GetComponentsInChildren<ItemSlotDisplay>())
        {
            slot.ClearSlot();
        }
        for (int i = 0; i < m_Inventory.m_Items.Count; i++)
        {
            if (i > 9) break;
            this.transform.GetChild(i).GetComponent<ItemSlotDisplay>().UpdateItem(m_Inventory.m_Items[i]);
        }
        m_CashText.text = m_Inventory.m_Cash.ToString();
    }
    
    public void OnItemPurchased(ShopItem item)
    {
        UpdateDisplay();
    }
    private void OnRewind()
    {
        m_Inventory.m_Cash = 225;
        m_Inventory.ClearItems();
        UpdateDisplay();
    }
}
