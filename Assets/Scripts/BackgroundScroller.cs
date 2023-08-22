using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Vector2 m_MoveSpeed;

    private Vector2 m_Offset;
    private Material m_Material;

    private void Awake()
    {
        m_Material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        m_Offset = m_MoveSpeed * Time.deltaTime;
        m_Material.mainTextureOffset += m_Offset;
    }
}
