using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int m_Score;

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

    public int GetScore()
    {
        return m_Score;
    }

    public void ModifyScore(int _Value)
    {
        m_Score += _Value;
        Mathf.Clamp(m_Score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        m_Score = 0;
    }
}
