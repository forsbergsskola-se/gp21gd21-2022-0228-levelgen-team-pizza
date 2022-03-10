using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth_PS : MonoBehaviour{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] private int potionHeal = 10;

    public PlayerHealthBarMT PlayerHealthBarMT;

    void Start(){
        currentHealth = maxHealth;
        PlayerHealthBarMT.SetMaxHealth(maxHealth);

    }

    private void Update()
    {
        ReloadOnDeath();
    }

    public void PlayerTakeDamage(int Damage){
        currentHealth -= Damage;
        PlayerHealthBarMT.SetHealth(currentHealth);
    }

    public void ReloadOnDeath()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            currentHealth += 10;
            PlayerHealthBarMT.SetHealth(currentHealth);
        }
    }
}
