using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;

    public float attack1Damage;
    public float attack2Damage;

    public Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void Initialize(float health, float damage1, float damage2)
    {
        maxHealth = health;
        currentHealth = health;
        attack1Damage = damage1;
        attack2Damage = damage2;
    }


    public void Attack1Damage()
    {
        currentHealth -= attack1Damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    public void Attack2Damage()
    {
        currentHealth -= attack2Damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // 处理怪物死亡
        animator.Play("Die");
        StartCoroutine(DieWait2());
    }

    IEnumerator DieWait2()
    {
        yield return new WaitForSeconds(2f); // 等待两秒
        Destroy(gameObject);
    }
}
