using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    private float m_MovementSpeed = 1f;

    [SerializeField]
    private Rigidbody2D m_Rb;
    [SerializeField]
    private Animator m_Animator;

    private Vector2 m_InputDirection;
    void Update()
    {
        CheckInput();
        UpdateAnimation();
        UpdateSpriteOrder();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void CheckInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        m_InputDirection = new Vector2(inputX, inputY);
    }
    private void UpdateAnimation()
    {
        m_Animator.SetFloat("Speed", m_InputDirection.magnitude);
    }
    private void UpdateSpriteOrder()
    {
        foreach(SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.sortingOrder = (int) (this.transform.position.y * -10);
            if (renderer.gameObject.CompareTag("AcessoryItem"))
                renderer.sortingOrder += 1;
        }
    }
    private void Move()
    {
        m_Rb.velocity = m_InputDirection.normalized * m_MovementSpeed * 3f;
    }
}
