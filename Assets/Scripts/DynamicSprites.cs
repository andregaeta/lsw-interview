using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSprites : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_HatRenderer;

    private void Awake()
    {
        EventSystem.itemEquipped.AddListener(OnItemEquip);
        EventSystem.rewinded.AddListener(OnRewind);
    }

    private void OnItemEquip(EquipmentObject equip)
    {
        m_HatRenderer.sprite = equip.m_Sprite;
    }

    private void OnRewind()
    {
        m_HatRenderer.sprite = null;
    }
}
