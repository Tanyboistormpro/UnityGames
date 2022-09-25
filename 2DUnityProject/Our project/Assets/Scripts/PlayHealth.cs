using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayHealth : MonoBehaviour
{
    public Rigidbody2D rb;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerTakeDamage(20);
        }

        if(currentHealth == 0)
        {
            Die();
        }
    }

    void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerTakeDamage(20);
        }

        if (other.CompareTag("DeathReseter"))
        {
            Die();
        }
    }

    void Die()
    {
        transform.position = PlayerPos.lastCheckpointPos;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
