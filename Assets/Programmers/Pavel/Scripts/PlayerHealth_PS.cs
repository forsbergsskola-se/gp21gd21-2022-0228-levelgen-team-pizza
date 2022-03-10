using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth_PS : MonoBehaviour{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;

    void Start(){
        currentHealth = maxHealth;
    }

    public void PlayerTakeDamage(int Damage){
        currentHealth -= Damage;
    }
}
