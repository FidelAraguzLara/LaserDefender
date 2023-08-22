using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float m_ShakeDuration;
    [SerializeField] private float m_ShakeMagnitude;

    private Vector3 m_InitialPosition;

    void Start()
    {
        m_InitialPosition = transform.position;
    }

    public void Shake()
    {
        StartCoroutine(ShakeScreen());
    }

    private IEnumerator ShakeScreen()
    {
        float a_ElapsedTime = 0f;

        while(a_ElapsedTime < m_ShakeDuration)
        {
            transform.position = m_InitialPosition + (Vector3)Random.insideUnitCircle * m_ShakeMagnitude;
            a_ElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = m_InitialPosition;
    }
}
