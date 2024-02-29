using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public int maxHealth = 3; 

    public GameManager gameManager;

    private int currentHealth; 
    private Animator animator; 

    void Start()
    {
        currentHealth = maxHealth; 
        animator = GetComponent<Animator>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) 
        {
            TakeDamage(); 
        }
    }

    void TakeDamage()
    {
        currentHealth--;
        Debug.Log("Hit!");
        animator.Play("JoggingStumble"); 

        if (currentHealth <= 0) 
        {
            Die(); 
        }
    }

    void Die()
    {
        animator.Play("StumbleBackwards"); 


        gameManager.GameOver();
        Destroy(gameObject);

    }
}
