using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth_PS : MonoBehaviour{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    void Start(){
        currentHealth = maxHealth;
    }

    private void Update()
    {
        ReloadOnDeath();
    }

    public void PlayerTakeDamage(int Damage){
        currentHealth -= Damage;
    }

    public void ReloadOnDeath()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
