using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] GameObject m_PanelFinish;

    private void Awake()
    {
        m_PanelFinish.SetActive(false);
    }

    public IEnumerator FinishLevel(string a_LevelToload, float a_Delay)
    {
        m_PanelFinish.gameObject.SetActive(true);

        yield return new WaitForSeconds(a_Delay);

        SceneManager.LoadScene(a_LevelToload);
    }
}
