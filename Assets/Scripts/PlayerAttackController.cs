using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Animator Canvasanimator;

    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public Slider healthSlider;

    public GameObject Attack1Effect = null;
    public GameObject Attack2Effect = null;

    public Text text1;
    public Text textnum;

    public int num;
    public Animator animator2;
    public GameObject dieUIBack;
    void Start()
    {
        animator = GetComponent<Animator>();
        //healthSlider = GetComponentInChildren<Slider>(); // ��ȡѪ��Slider���
        healthSlider.minValue = 0f; // ��СֵΪ0
        healthSlider.maxValue = maxHealth; // ���ֵΪmaxHealth

        healthSlider.value = currentHealth; // ��Ѫ��Slider�ĵ�ǰֵ��Ϊ��ǰѪ��ֵ


    }
    public void KillGhost()
    {
        num++;
        textnum.text = num.ToString();
        if (num == 1)
        {
            animator2.Play("Fadein");
            PlayerPrefs.SetInt("unlockedLevelIndex", 2);
        }
        
    }
    public void BacktoChoose1()
    {
        SceneManager.LoadScene("FourSeasons");
    }
    void Update()
    {

        healthSlider.value = currentHealth; // ��Ѫ��Slider�ĵ�ǰֵ��Ϊ��ǰѪ��ֵ
        text1.text = currentHealth.ToString();
        if (Input.GetKeyDown(KeyCode.H))
        {
            Attack1();

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack2();

        }


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
                // ������1�˺�
                EnemyController enemyController = nearestEnemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    //isAttack1 = true;
                    animator.Play("attack1");
                    GameObject attack1 = Instantiate(Attack1Effect, nearestEnemy.transform.position, Quaternion.identity);
                    enemyController.Attack1Damage();
                }

            }
        }
        else
        {
            // ��ȡ���ﵱǰ����ķ���
            Vector3 direction = transform.forward;
            // ��������ǰ���� 7 ��
            Vector3 spawnPosition = transform.position + direction * 7f;
            animator.Play("attack1");
            GameObject attack1 = Instantiate(Attack1Effect, spawnPosition, Quaternion.identity);

        }
    }

    void Attack2()
    {
        // ��������������ú�ɨ������Χ�Ĳ���
        float sweepRadius = 11f; // ��ɨ�����İ뾶
        float sweepLength = 9f; // ��ɨ�����ĳ���

        // �����ɨ������Χ����ʼ�����ֹ��
        Vector3 sweepStart = transform.position + transform.forward * attack1Range * 0.5f; // ������Χ����ʼ��
        Vector3 sweepEnd = sweepStart + transform.forward * sweepLength; // ������Χ����ֹ��

        // ���ƹ�����Χ���߶�
        Debug.DrawLine(sweepStart, sweepEnd, Color.red, 5f);

        // �ں�ɨ��Χ�ڼ����ײ��
        Collider[] hitEnemies = Physics.OverlapCapsule(sweepStart, sweepEnd, sweepRadius, enemyLayer);

        // ���Ź�������
        animator.Play("attack2");
        GameObject attack2 = Instantiate(Attack2Effect, transform.position, Quaternion.identity);
        foreach (Collider enemy in hitEnemies)
        {
            // �������˺�
            EnemyController enemyController = enemy.GetComponent<EnemyController>();

            if (enemyController != null)
            {


                // ִ�е����ܵ��������߼�
                enemyController.Attack2Damage();
            }
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //healthSlider.value = currentHealth;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    /*IEnumerator DieWait5()
    {
        yield return new WaitForSeconds(1f); // �ȴ�����
        Time.timeScale = 0;
    }*/
    public void Die()
    {
        Debug.Log("Die");
        //Time.timeScale = 0;
        /*if (num < 1)
        {
            dieUIBack.SetActive(false);
        }
        else
        {
            dieUIBack.SetActive(true);
        }*/
        Canvasanimator.Play("Fadein");
        //StartCoroutine(DieWait5());

    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }
}
