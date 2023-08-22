using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int m_Damage = 10;

    public int GetDamage()
    {
        return m_Damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
