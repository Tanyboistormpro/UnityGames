using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemyMaxHealth = 100;
    public int EnemyCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyCurrentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        EnemyCurrentHealth -= damage;
    }
}
