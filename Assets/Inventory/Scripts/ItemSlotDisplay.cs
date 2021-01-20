using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotDisplay : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image m_IconImage;
    [SerializeField] private Text m_CountText;
    private ItemObject m_Item;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_Item == null) return;
        if (m_Item is EquipmentObject)
            EventSystem.itemEquipped.Invoke((EquipmentObject) m_Item);
    }

    public void UpdateItem(ItemSlot itemSlot)
    {
        m_Item = itemSlot.m_Item;
        m_IconImage.sprite = itemSlot.m_Item.m_Icon;
        m_IconImage.color = Color.white;
        m_CountText.text = (itemSlot.m_Amount > 1) ? itemSlot.m_Amount.ToString() : "";
    }
    public void ClearSlot()
    {
        m_Item = null;
        m_IconImage.sprite = null;
        m_IconImage.color = Color.clear;
        m_CountText.text = "";
    }
}
