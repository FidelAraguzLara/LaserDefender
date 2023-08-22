using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float m_MovementSpeed;

    Vector2 m_RawInput;
    
    Vector2 m_MinBound;
    Vector2 m_MaxBound;

    [SerializeField] float m_RightPadding;
    [SerializeField] float m_LeftPadding;
    [SerializeField] float m_TopPadding;
    [SerializeField] float m_BottomPadding;

    private Shooter m_Shooter;

    private void Awake()
    {
        m_Shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        PlayerMove();
    }

    void InitBounds()
    {
        Camera a_MainCamera = Camera.main;

        m_MinBound = a_MainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        m_MaxBound = a_MainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void PlayerMove()
    {
        Vector2 a_Delta = m_RawInput * m_MovementSpeed * Time.deltaTime;
        Vector2 a_NewPosition = new Vector2();

        a_NewPosition.x = Mathf.Clamp(transform.position.x + a_Delta.x, m_MinBound.x + m_LeftPadding, m_MaxBound.x - m_RightPadding);
        a_NewPosition.y = Mathf.Clamp(transform.position.y + a_Delta.y, m_MinBound.y + m_BottomPadding, m_MaxBound.y - m_TopPadding);

        transform.position = a_NewPosition;
    }

    void OnMove(InputValue a_Value)
    {
        m_RawInput = a_Value.Get<Vector2>();
    }

    void OnFire(InputValue _Value)
    {
        if (m_Shooter != null)
        {
            m_Shooter.m_IsFiring = _Value.isPressed;
        }
    }
}
