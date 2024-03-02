using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObstacleCollision : MonoBehaviour
{
    public int maxHealth = 3; 
    public static int lives = 3;

    public GameManager gameManager;

    private int currentHealth; 
    private Animator animator;

    private bool canInteract = true;
    public float interactionCooldown = 3f;

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
        if (canInteract)
        {
            currentHealth--;
            lives--;
            animator.Play("JoggingStumble");

            if (currentHealth <= 0)
            {
                Die();
            }

            StartCoroutine(DisableInteractionForCooldown());
        }
    }
    IEnumerator DisableInteractionForCooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(interactionCooldown);
        canInteract = true;
    }

    void Die()
    {
        animator.Play("StumbleBackwards"); 


        gameManager.GameOver();
        //Destroy(gameObject);

    }
}
