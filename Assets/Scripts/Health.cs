using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool m_IsPlayer;
    [SerializeField] int m_Health = 50;
    [SerializeField] int m_Score = 0;
    [SerializeField] private ParticleSystem m_ExplosionEffect;

    private AudioPlayer m_AudioPlayer;

    [SerializeField] bool m_ApplyShake;
    [SerializeField] bool m_PlayerDamage;
    CameraShake m_CameraShake;
    ScoreKeeper m_ScoreKeeper;
    LevelManager m_LevelManager;

    private void Awake()
    {
        m_ScoreKeeper = FindObjectOfType<ScoreKeeper>();
        m_AudioPlayer = FindObjectOfType<AudioPlayer>();
        m_CameraShake = Camera.main.GetComponent<CameraShake>();
        m_LevelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer a_DamageDealer = collision.GetComponent<DamageDealer>();
        
        if(a_DamageDealer != null)
        {
            TakeDamage(a_DamageDealer.GetDamage());
            Shake();
            PlayDamageEffect();
            PlayPlayerDamage();
            a_DamageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return m_Health;
    }

    void TakeDamage(int a_Damage)
    {
        m_Health -= a_Damage;
        
        if(m_Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!m_IsPlayer)
        {
            m_ScoreKeeper.ModifyScore(m_Score);
        }
        else
        {
            m_LevelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    private void PlayDamageEffect()
    {
        if (m_ExplosionEffect != null)
        {
            ParticleSystem a_Instance = Instantiate(m_ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(a_Instance.gameObject, a_Instance.main.duration + a_Instance.main.startLifetime.constantMax);
        }
    }

    private void Shake()
    {
        if(m_CameraShake != null && m_ApplyShake)
        {
            m_CameraShake.Shake();
        }
    }

    private void PlayPlayerDamage()
    {
        if (m_AudioPlayer != null && m_PlayerDamage)
        {
            m_AudioPlayer.PlayDamageClip();
        }
    }
}
