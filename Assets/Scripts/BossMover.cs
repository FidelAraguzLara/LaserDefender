using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    private float m_Speed = 2f;
    private Vector3 m_TargetPosition;
    private Vector3 m_StartLeftPosition;
    private Vector3 m_StartRightPosition;
    private bool m_MovingRight = true;

    private void Start()
    {
        m_StartLeftPosition = m_TargetPosition + Vector3.left * 2f; // Offset de inicio a la izquierda.
        m_StartRightPosition = m_TargetPosition + Vector3.right * 2f; // Offset de inicio a la derecha.
    }

    private void Update()
    {
        if (m_MovingRight)
        {
            MoveToTarget(m_StartRightPosition);
            if (Vector3.Distance(transform.position, m_StartRightPosition) < 0.01f)
            {
                m_MovingRight = false;
            }
        }
        else
        {
            MoveToTarget(m_StartLeftPosition);
            if (Vector3.Distance(transform.position, m_StartLeftPosition) < 0.01f)
            {
                m_MovingRight = true;
            }
        }
    }

    public void SetTargetPosition(Vector3 a_Target)
    {
        m_TargetPosition = a_Target;
    }

    private void MoveToTarget(Vector3 a_Destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, a_Destination, m_Speed * Time.deltaTime);
    }
}
