using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeteors : MonoBehaviour
{
    private Transform m_Transform;

    void Start()
    {
        m_Transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (m_Transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
}
