using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;

    public float attack1Damage;
    public float attack2Damage;

    public Slider healthSlider;

    public Animator animator;
    public GameObject player;

    public bool flag;
    void Start()
    {

        flag = false;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        healthSlider = GetComponentInChildren<Slider>(); // 获取血条Slider组件
        healthSlider.minValue = 0f; // 最小值为0
        healthSlider.maxValue = maxHealth; // 最大值为maxHealth

        healthSlider.value = currentHealth; // 将血条Slider的当前值设为当前血量值
    }
    public void Initialize(float health, float damage1, float damage2)
    {
        maxHealth = health;
        currentHealth = health;
        attack1Damage = damage1;
        attack2Damage = damage2;
    }
    void Update()
    {

    }



    public void Attack1Damage()
    {
        currentHealth -= attack1Damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0f && !flag)
        {
            flag = true;
            Die();

        }
    }
    public void Attack2Damage()
    {
        currentHealth -= attack2Damage;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0f && !flag)
        {
            flag = true;
            Die();

        }

    }

    void Die()
    {
        // 处理怪物死亡
        animator.Play("Die");
        print("diedieidie");
        player.GetComponent<PlayerAttackController>().KillGhost();
        Destroy(gameObject);
        //StartCoroutine(DieWait2());
    }

    IEnumerator DieWait2()
    {

        yield return new WaitForSeconds(1f); // 等待两秒
        Destroy(gameObject);
    }
}
