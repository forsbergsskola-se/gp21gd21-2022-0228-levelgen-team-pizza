using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth_PS : MonoBehaviour{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    public PlayerHealthBarMT playerHealthBarMT;



    void Start(){
        currentHealth = maxHealth;
        playerHealthBarMT.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        ReloadOnDeath();
    }

    public void PlayerTakeDamage(int Damage){
        currentHealth -= Damage;
        playerHealthBarMT.SetHealth(currentHealth);
    }

    public void ReloadOnDeath()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
