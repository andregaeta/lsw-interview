using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField] private Inventory m_PlayerInventory;
    [SerializeField] private GameObject m_ShopPanel;
    [SerializeField] private Image m_ItemPreviewImage;
    [SerializeField] private Text m_PriceText;
    private ShopInventory m_ShopInventory;
    private int m_PreviewIndex;
    private bool m_ShopIsOpen = false; 
    private void Awake()
    {
        EventSystem.shopOpened.AddListener(OnShopTrigger);
        CloseShop();
    }
    public void OpenShop()
    {
        m_ShopPanel.SetActive(true);
        UpdatePreview(0);
    }
    public void CloseShop()
    {
        m_ShopPanel.SetActive(false);
    }
    public void PreviousPreview()
    {
        UpdatePreview(m_PreviewIndex - 1);
    }
    public void NextPreview()
    {
        UpdatePreview(m_PreviewIndex + 1);
    }
    public void BuyItem()
    {
        ShopItem currentItem = m_ShopInventory.m_Items[m_PreviewIndex];
        if (m_PlayerInventory.m_Cash < currentItem.m_Price) return;

        m_PlayerInventory.m_Cash -= currentItem.m_Price;
        m_PlayerInventory.AddItem(currentItem.m_Item);
        m_ShopInventory.m_Items[m_PreviewIndex].m_Purchased = true;

        EventSystem.itemPurchased.Invoke(currentItem);
    }
    private void OnShopTrigger(ShopInventory inventory)
    {
        if (m_ShopIsOpen) return;
        m_ShopInventory = inventory;
        OpenShop();
    }
    private void UpdatePreview(int index)
    {
        if (index >= m_ShopInventory.m_Items.Count || index < 0) return;
        m_PreviewIndex = index;
        m_ItemPreviewImage.sprite = m_ShopInventory.m_Items[m_PreviewIndex].m_Item.m_Sprite;
        m_PriceText.text = m_ShopInventory.m_Items[m_PreviewIndex].m_Price.ToString();
    }
}

