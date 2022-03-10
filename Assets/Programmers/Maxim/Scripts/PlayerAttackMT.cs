using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMT : MonoBehaviour
{

    private Animator animator;
    private EnemyHealth_PS enemyHealth;
    private Transform enemy;
    private float distanceToEnemy;
    private bool noObstacle;


    [SerializeField] int damage;
    [SerializeField] float attackRange = 10f;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth_PS>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && EnemyInAttackRange())
        {
            Attack();
        }

    }

    bool EnemyInAttackRange()
    {

        distanceToEnemy =  Vector3.Distance(transform.position, enemy.position);
        Vector3 direction = enemy.position - this.transform.position;
        if (Physics.Raycast(transform.position, direction, out var hit))
        {
            noObstacle = hit.transform.CompareTag("Enemy");
        }

        if (noObstacle && distanceToEnemy <= attackRange)
        {
            return true;
        }

        return false;
    }

    void Attack()
    {
        //Damage them
        enemyHealth.TakeDamage(damage);

        //Play Animation
        animator.SetTrigger("Attack");

    }
}
