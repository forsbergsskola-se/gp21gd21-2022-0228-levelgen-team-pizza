using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerAttackMT : MonoBehaviour
{
    private Animator animator;
    private EnemyHealth_PS enemyHealth;
    private Transform enemy;
    private float distanceToEnemy;
    private bool noObstacle;


    [SerializeField] int damage = 10;


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            //Damage them
            collisionInfo.gameObject.GetComponent<EnemyHealth_PS>().TakeDamage(damage); //Does not exist on player

            //Play Animation
            animator.SetTrigger("Attack");

        }
    }
}
