using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth_PS : MonoBehaviour{
    [SerializeField] int currentHealth = 20;
    [SerializeField] bool isEnemyDead;


    public void TakeDamage(int Damage){
        currentHealth -= Damage;

        if (currentHealth <= 0 && isEnemyDead == false){
            //gameObject.GetComponent<Animator>().Play();
            isEnemyDead = true;
            Destroy(gameObject);
        }
    }
}
