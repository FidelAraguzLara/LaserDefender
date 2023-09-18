using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip m_Shooting;
    [SerializeField] AudioClip m_DamageTaken;
    [SerializeField][Range(0f, 1f)] private float m_Volume = 0.5f;

    [Header("OST")]
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_MainMenuOST;
    [SerializeField] AudioClip m_Level1OST;
    [SerializeField] AudioClip m_Level2OST;
    [SerializeField] AudioClip m_Level3OST;
    [SerializeField] AudioClip m_GameOverOST;

    private void Awake()
    {
        ManageSingleton();
    }

    private void Start()
    {
        ChangeBackgroundMusic(m_MainMenuOST);

        SceneManager.sceneLoaded += BackgroundMusic;
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

    private void BackgroundMusic(Scene scene, LoadSceneMode mode)
    {
        string _SceneName = SceneManager.GetActiveScene().name;

        switch (_SceneName)
        {
            case "MainMenu":
                ChangeBackgroundMusic(m_MainMenuOST);
                break;
            case "Level 1":
                ChangeBackgroundMusic(m_Level1OST);
                break;
            case "Level 2":
                ChangeBackgroundMusic(m_Level2OST);
                break;
            case "Level 3":
                ChangeBackgroundMusic(m_Level3OST);
                break;
            case "GameOver":
                ChangeBackgroundMusic(m_GameOverOST);
                break;
        }
    }

    private void ChangeBackgroundMusic(AudioClip a_NewClip)
    {
        m_AudioSource.clip = a_NewClip;
        m_AudioSource.Play();
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
