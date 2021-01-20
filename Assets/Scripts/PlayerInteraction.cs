using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float m_UpdateInterval = 0.25f;
    [SerializeField] private HashSet<GameObject> m_NearbyInteractables = new HashSet<GameObject>();
    [SerializeField] private LayerMask m_RaycastIgnoreLayer;

    private float m_TimeSinceLastUpdate = 0f;
    private GameObject m_ClosestInteractable = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (!CheckIfInteractable(otherObj)) return;

        m_NearbyInteractables.Add(otherObj);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (!CheckIfInteractable(otherObj)) return;

        m_NearbyInteractables.Remove(otherObj);
    }
    private void Update()
    {
        m_TimeSinceLastUpdate += Time.deltaTime;
        CheckInteractables();
    }
    private void CheckInteractables()
    {
        GameObject closestInteractable = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject obj in m_NearbyInteractables)
        {
            var dist = Vector2.Distance(this.transform.position, obj.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestInteractable = obj;
            }
        }

        if (closestInteractable != null)
        {
            Debug.DrawLine(this.transform.position, closestInteractable.transform.position, Color.green);
        }
        TrySetClosestInteractable(closestInteractable);
    }

    private void TrySetClosestInteractable(GameObject interactable)
    {
        if (interactable == m_ClosestInteractable || m_TimeSinceLastUpdate < m_UpdateInterval) return;
        StopInteraction();
        if (interactable == null) return;
        interactable.GetComponent<IWorldInteractable>().Interact();
        m_ClosestInteractable = interactable;
        m_TimeSinceLastUpdate = 0f;
    }
    private void StopInteraction()
    {
        if (m_ClosestInteractable != null)
            m_ClosestInteractable.GetComponent<IWorldInteractable>().StopInteraction();
        m_ClosestInteractable = null;
    }

    private bool CheckIfInteractable(GameObject obj)
    {
        IWorldInteractable interactable = obj.GetComponent<IWorldInteractable>();
        return interactable != null;
    }
}
