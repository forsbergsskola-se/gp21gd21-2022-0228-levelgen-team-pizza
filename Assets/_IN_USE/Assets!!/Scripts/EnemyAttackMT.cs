using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMT : MonoBehaviour
{
    [SerializeField] int damage = 10;




    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            //Damage them
            collisionInfo.gameObject.GetComponent<PlayerHealth_PS>().PlayerTakeDamage(damage);

        }
    }
}
