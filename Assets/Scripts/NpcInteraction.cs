using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour, IWorldInteractable
{
    [SerializeField] private GameObject m_TooltipPrefab = null;
    [SerializeField] ShopInventory m_ShopInventory;
    private GameObject m_Tooltip;
    private bool m_Interacting;
    public void Interact()
    {
        m_Tooltip = Instantiate(m_TooltipPrefab, this.transform);
        m_Tooltip.GetComponent<WorldInteractionTooltip>().SetupToObject(this.gameObject);
        m_Interacting = true;
    }

    public void StopInteraction()
    {
        m_Tooltip.GetComponent<WorldInteractionTooltip>().DestroyTooltip();
        m_Tooltip = null;
        m_Interacting = false;
    }


    private void Update()
    {
        if (m_Interacting && Input.GetKeyDown(KeyCode.Space))
        {
            EventSystem.shopOpened.Invoke(m_ShopInventory);
        }
    }
}
