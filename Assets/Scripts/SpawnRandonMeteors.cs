using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandonMeteors : MonoBehaviour
{
    [SerializeField] private LevelChanger m_LevelChanger;
    [SerializeField] private List<GameObject> m_Meteors;
    [SerializeField] private float m_FixedYPosition = 0f; 
    [SerializeField] private float m_XMinBound = -5f;
    [SerializeField] private float m_XMaxBound = 5f;   
    [SerializeField] private float m_MeteorMinSpeed = 2f;
    [SerializeField] private float m_MeteorMaxSpeed = 5f;
    [SerializeField] private float m_MeteorSpawnTime = 2f; 
    [SerializeField] private float m_LevelDuration = 0f;
    private float m_ElapsedTime = 0f;
   

    void Start()
    {
        StartCoroutine(SpawnObjectsContinuously());
    }

    IEnumerator SpawnObjectsContinuously()
    {
        while (m_ElapsedTime < m_LevelDuration) 
        {
            GameObject _MeteorPrefab = m_Meteors[Random.Range(0, m_Meteors.Count)];

            float _RandomXPosition = Random.Range(m_XMinBound, m_XMaxBound);

            GameObject _NewMeteor = Instantiate(_MeteorPrefab, new Vector3(_RandomXPosition, m_FixedYPosition, 0f), Quaternion.identity);

            float _RandomMeteorSpeed = Random.Range(m_MeteorMinSpeed, m_MeteorMaxSpeed);
            
            Rigidbody2D _MeteorRigidBody2D = _NewMeteor.GetComponent<Rigidbody2D>();
            
            if (_MeteorRigidBody2D != null)
            {
                _MeteorRigidBody2D.velocity = new Vector2(0f, -_RandomMeteorSpeed);
            }
            else
            {
                Debug.LogError("El objeto no tiene un Rigidbody2D.");
            }

            yield return new WaitForSeconds(m_MeteorSpawnTime);

            m_ElapsedTime += m_MeteorSpawnTime;
        }

        StartCoroutine(m_LevelChanger.FinishLevel("Level 3", 2));
    }
}
