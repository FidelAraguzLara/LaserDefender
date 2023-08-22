using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip m_Shooting;
    [SerializeField] AudioClip m_DamageTaken;
    [SerializeField][Range(0f, 1f)] private float m_Volume = 0.5f;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        int a_InstanceType = FindObjectsOfType(GetType()).Length;

        if (a_InstanceType > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        if (m_Shooting != null)
        {
            AudioSource.PlayClipAtPoint(m_Shooting, Camera.main.transform.position, m_Volume);
        }
    }

    public void PlayDamageClip()
    {
        if (m_Shooting != null)
        {
            AudioSource.PlayClipAtPoint(m_DamageTaken, Camera.main.transform.position, m_Volume);
        }
    }
}
