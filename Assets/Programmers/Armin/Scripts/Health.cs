using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth, maxHealth;
    private bool isEntityDead;


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && isEntityDead == false)
        {
            gameObject.SetActive(false);
            isEntityDead = true;
        }

        
    }

}
