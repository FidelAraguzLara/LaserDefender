using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject m_ProjectilePrefab;
    [SerializeField] private float m_ProjectileSpeed;
    [SerializeField] private float m_ProjectileLifeTime;
    [SerializeField] private float m_BaseFireRate;

    [Header("IA")]
    [SerializeField] private bool m_UseIA;
    [SerializeField] private float m_FireRateVariance;
    [SerializeField] private float m_MinimunFireRate;
    
    [HideInInspector] public bool m_IsFiring;

    private Coroutine m_FiringCoroutine;

    private AudioPlayer m_AudioPlayer;

    private void Awake()
    {
        m_AudioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (m_UseIA)
        {
            m_IsFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (m_IsFiring && m_FiringCoroutine == null)
        {
            m_FiringCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!m_IsFiring && m_FiringCoroutine!= null)
        {
            StopCoroutine(m_FiringCoroutine);
            m_FiringCoroutine = null;
        }
    }

    private IEnumerator FireContinuosly()
    {
        float a_ProjectileSpawn;

        while(true)
        {
            GameObject a_Instance = Instantiate(m_ProjectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D a_RigidBody = a_Instance.GetComponent<Rigidbody2D>();

            if(a_RigidBody != null)
            {
                a_RigidBody.velocity = transform.up * m_ProjectileSpeed;
            }

            Destroy(a_Instance, m_ProjectileLifeTime);

            if (m_UseIA)
            {
                a_ProjectileSpawn = Random.Range(m_BaseFireRate - m_FireRateVariance, m_BaseFireRate + m_FireRateVariance);
                a_ProjectileSpawn = Mathf.Clamp(a_ProjectileSpawn, m_MinimunFireRate, float.MaxValue);
            }
            else
            {
                a_ProjectileSpawn = m_BaseFireRate;
            }

            m_AudioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(a_ProjectileSpawn);
        }
    }
}
