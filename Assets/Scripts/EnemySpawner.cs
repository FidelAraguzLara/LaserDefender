using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> m_WavesConfigs;
    [SerializeField] float m_TimeBetweenWaves = 0f;
    [SerializeField] bool m_IsLooping = true;
    WaveConfigSO m_CurrentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return m_CurrentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO a_Wave in m_WavesConfigs)
            {
                m_CurrentWave = a_Wave;

                for (int i = 0; i < m_CurrentWave.GetEnemyCount(); i++)
                {
                    Instantiate(m_CurrentWave.GetEnemyPrefab(0), m_CurrentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, 180), transform);

                    yield return new WaitForSeconds(m_CurrentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(m_TimeBetweenWaves);
            }
        }
        while (m_IsLooping);   
    }
}
