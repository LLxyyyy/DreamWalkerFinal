using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    
    public float attack1Damage = 10f;
    public float attack2Damage = 20f;

    public Transform attack1Origin;
    public Transform attack2Origin;

    public float attack1Range = 7f;
    public float attack2Angle = 45f;

    public LayerMask enemyLayer;

    private Animator animator;

    public float currentHealth = 100f;

    public bool isAttack1 = false;
    public bool isAttack2 = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 处理攻击
        if (Input.GetKeyDown(KeyCode.H))
        {
            Attack1();
            isAttack1 = false;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack2();
            isAttack1 = false;
        }
        /*if(!isAttack1)
        {
            animator.SetBool("IsAttack1", true); 
        }
        else
        {
            animator.SetBool("IsAttack1", false);
        }*/
    }

    void Attack1()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attack1Origin.position, attack1Range, enemyLayer);
        if (hitEnemies.Length > 0)
        {
            float minDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (Collider enemy in hitEnemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy.gameObject;
                }
            }

            if (nearestEnemy != null)
            {
                // 处理攻击1伤害
                EnemyController enemyController = nearestEnemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    //isAttack1 = true;
                    animator.Play("attack1");
                    enemyController.Attack1Damage();
                }
            }
        }
    }

    void Attack2()
    {
        Collider[] hitEnemies = Physics.OverlapCapsule(attack2Origin.position, attack2Origin.position + attack2Origin.forward * attack1Range, attack1Range, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            // 处理攻击2伤害
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                //isAttack2 = true;
                
                enemyController.Attack1Damage();
            }
        }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // 处理角色死亡
        // ...
    }
}
