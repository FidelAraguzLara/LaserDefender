using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float m_Delay = 2f;
    ScoreKeeper m_ScoreKeeper;

    private void Awake()
    {
        m_ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
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
