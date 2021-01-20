using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldInteractionTooltip : MonoBehaviour
{
    [SerializeField] private float m_OffsetX = 0f;
    [SerializeField] private float m_OffsetY = 0f;
    public void SetupToObject(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        pos.x += m_OffsetX;
        pos.y += m_OffsetY;
        this.transform.position = pos;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color oldColor = renderer.color;
        Color offsetColor = oldColor;
        offsetColor.a = 0;
        renderer.color = offsetColor;
        renderer.DOColor(oldColor, 0.5f).SetEase(Ease.InOutCubic);
    }
    public void DestroyTooltip()
    {
        Destroy(this.gameObject, 0.55f);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color offsetColor = renderer.color;
        offsetColor.a = 0;
        renderer.DOColor(offsetColor, 0.5f).SetEase(Ease.InOutCubic);
    }
}
