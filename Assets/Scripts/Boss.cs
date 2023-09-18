using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private LevelChanger m_LevelChanger;
    [SerializeField] private GameObject m_BossPrefab;

    private void Awake()
    {
        m_LevelChanger = GetComponent<LevelChanger>();
    }

    private void Update()
    {
        if (m_BossPrefab == null)
        {
            m_LevelChanger.FinishLevel("MainMenu", 2);
        }
    }
}
