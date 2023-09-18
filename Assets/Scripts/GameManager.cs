using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float m_Delay = 2f;
    private bool m_IsPaused = false;
    ScoreKeeper m_ScoreKeeper;

    private void Awake()
    {
        m_ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnPause(InputValue a_InputValue)
    {
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            return;
        }

        if (a_InputValue.Get<float>() == 1f)
        {
            m_IsPaused = !m_IsPaused;

            if (m_IsPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadMainMenu()
    {
        m_ScoreKeeper.ResetScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadDelay("GameOver", m_Delay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadDelay(string _Scene, float _Delay)
    {
        yield return new WaitForSeconds(_Delay);
        SceneManager.LoadScene(_Scene);
    }
}
