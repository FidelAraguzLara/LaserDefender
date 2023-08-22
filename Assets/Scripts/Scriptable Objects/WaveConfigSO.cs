using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> m_EnemiesPrefabs;
    [SerializeField] Transform m_PathPrefab;
    [SerializeField] float m_EnemyMoveSpeed = 5f;
    [SerializeField] float m_TimeBetweenEnemySpawn = 1f;
    [SerializeField] float m_SpawnTimeVariance = 0f;
    [SerializeField] float m_MinimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return m_PathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> a_Waypoints = new List<Transform>();

        foreach (Transform child in m_PathPrefab)
        {
            a_Waypoints.Add(child);
        }

        return a_Waypoints;
    }

    public float GetEnemyMovementSpeed()
    {
        return m_EnemyMoveSpeed;
    }

    public GameObject GetEnemyPrefab(int a_Index)
    {
        return m_EnemiesPrefabs[a_Index];
    }

    public int GetEnemyCount()
    {
        return m_EnemiesPrefabs.Count;
    }

    public float GetRandomSpawnTime()
    {
        float a_SpawnTime = Random.Range(m_TimeBetweenEnemySpawn - m_SpawnTimeVariance, m_TimeBetweenEnemySpawn + m_SpawnTimeVariance);

        return Mathf.Clamp(a_SpawnTime, m_MinimumSpawnTime, float.MaxValue);
    }
}
