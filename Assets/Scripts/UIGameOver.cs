using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TMP_Text m_ScoreText;
    private ScoreKeeper m_ScoreKeeper;

    private void Awake()
    {
        m_ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        m_ScoreText.text = m_ScoreKeeper.GetScore().ToString("000000000");
    }
}
