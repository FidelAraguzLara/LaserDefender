using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner m_EnemySpawner;
    WaveConfigSO m_WaveConfigSO;
    List<Transform> m_Waypoints;
    int m_WayPointIndex = 0;

    void Awake()
    {
        m_EnemySpawner = FindObjectOfType<EnemySpawner>();   
    }

    void Start()
    {
        m_WaveConfigSO = m_EnemySpawner.GetCurrentWave();
        m_Waypoints = m_WaveConfigSO.GetWaypoints();
        transform.position = m_Waypoints[0].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (m_WayPointIndex < m_Waypoints.Count)
        {
            Vector3 a_TargetPosition = m_Waypoints[m_WayPointIndex].position;
            float a_Delta = m_WaveConfigSO.GetEnemyMovementSpeed() * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, a_TargetPosition, a_Delta);

            if(transform.position == a_TargetPosition)
            {
                m_WayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
