using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text m_ScoreText;
    [SerializeField] private Slider m_Slider;
    [SerializeField] private Health m_Health;
    private ScoreKeeper m_ScoreKeeper;

    private void Awake()
    {
        m_ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        m_Slider.maxValue = m_Health.GetHealth();
    }

    void Update()
    {
        m_Slider.value = m_Health.GetHealth();
        m_ScoreText.text = m_ScoreKeeper.GetScore().ToString("000000000");
    }

}
