using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    GameObject m_BossObject;
    [SerializeField] private GameObject m_BossPrefab;
    [SerializeField] private Transform m_SpawnPoint;
    
    [SerializeField] private Vector3 m_TargetPosition;
    [SerializeField] private Vector3 m_LeftTargetPosition;
    [SerializeField] private Vector3 m_RightTargetPosition;

    [SerializeField] private LevelChanger m_Changer;

    private void Start()
    {
        SpawnBoss();
    }

    private void Update()
    {
        if (m_BossObject == null)
        {
            StartCoroutine(m_Changer.FinishLevel("MainMenu", 2));
        }
    }

    private void SpawnBoss()
    {
        m_BossObject = Instantiate(m_BossPrefab, m_SpawnPoint.position, Quaternion.Euler(0, 0, 180));

        BossMover bossMover = m_BossObject.AddComponent<BossMover>();
        bossMover.SetTargetPosition(m_TargetPosition);
    }
}
