using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public Transform player;
    public Vector3 spawnPosition; // ����ĳ�����
    public float walkingSpeed; // ������ˮ���ϵ������ٶ�
    public float patrolRange; // Ѳ�߷�Χ

    public float attackRange; // ������Χ
    public float attackDamage; // ������Χ
    public bool isWaitingForAttack;

    public LayerMask PlayerLayer;
    public GameObject AttackEffect;

    private Animator animator;
    private Rigidbody rb;
    public List<Vector3> patrolPoints;
    public int currentPatrolIndex = 0;

    void Start()
    {
        walkingSpeed = 5.0f; // ������ˮ���ϵ������ٶ�
        patrolRange = 20f; // Ѳ�߷�Χ

        attackRange = 7f;
        attackDamage = 5f;
        isWaitingForAttack = false;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();



        spawnPosition = transform.position;

        // ʵ����Ѳ�ߵ��б�
        patrolPoints = new List<Vector3>();
        patrolPoints.Add(spawnPosition); // ʹ�� Add ������ӵ�һ��Ѳ�ߵ�

        // �������Ѳ�ߵ�
        for (int i = 0; i < 3; i++)
        {
            patrolPoints.Add(GetRandomPointOnWaterSurface(spawnPosition, patrolRange));
        }

        // �ڷ�Χ��ÿ�� 1 �빥��һ�����
        InvokeRepeating("Attack", 0f, 1f);

    }
    void Attack()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= 7)
        {
            StartCoroutine(WaitAttack());
        }


    }
    IEnumerator WaitAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, PlayerLayer);
        animator.Play("Attack");
        yield return new WaitForSeconds(0.3f); // �ȴ������������
        if (hitEnemies.Length > 0)
        {
            Collider playerAttack = hitEnemies[0];

            // ������1�˺�
            PlayerAttackController playerAttackController = playerAttack.GetComponent<PlayerAttackController>();
            if (playerAttackController != null)
            {
                //isAttack1 = true;

                GameObject attack = Instantiate(AttackEffect, playerAttack.transform.position, Quaternion.identity);
                playerAttackController.TakeDamage(attackDamage);
                //Debug.Log(attackDamage);

            }

            //isWaitingForAttack = false;
        }
        else
        {
            // ��ȡ���ﵱǰ����ķ���
            Vector3 direction = transform.forward;
            // ��������ǰ���� 7 ��
            Vector3 spawnPosition = transform.position + direction * 7f;
            //animator.Play("Attack");
            GameObject attack1 = Instantiate(AttackEffect, spawnPosition, Quaternion.identity);

        }
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer > 7 && distanceToPlayer < 25)
        {
            Track();
            //Debug.Log("track");
        }

        else if (distanceToPlayer >= 25)
        {
            Patrol();
            //Debug.Log("patrol");

        }
    }

    void Track()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * walkingSpeed * Time.deltaTime;

        // ������߶��Ƿ����ˮ��߶�
        if (transform.position.y < 13f)
        {
            transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
        }
        Vector3 playerPosition = player.position;
        playerPosition.y = transform.position.y; // ������ˮ���ϵĸ߶�
        transform.LookAt(playerPosition);
        //transform.LookAt(player.position);
        animator.Play("Walk");
    }

    void Patrol()
    {
        float distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex]);

        if (distanceToPatrolPoint < 1f)
        {
            animator.Play("Idle");
            //Debug.Log(patrolPoints.Count);
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            animator.Play("Walk");
            Vector3 direction = (patrolPoints[currentPatrolIndex] - transform.position).normalized;
            transform.position += direction * walkingSpeed * Time.deltaTime;

            // ������߶��Ƿ����ˮ��߶�
            if (transform.position.y < 13f)
            {
                transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
            }

            transform.LookAt(patrolPoints[currentPatrolIndex]);
        }
    }





    Vector3 GetRandomPointOnWaterSurface(Vector3 center, float range, int retryCount = 0)
    {
        if (retryCount > 100)
        {
            Debug.Log("Exceeded maximum retry count, returning center point.");
            return center;
        }

        Vector2 randomPoint = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
        Vector3 randomPosition = new Vector3(center.x + randomPoint.x, center.y, center.z + randomPoint.y);
        RaycastHit hit;

        if (Physics.Raycast(randomPosition + Vector3.up * 100f, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("WaterAttack")))
        {
            //randomPosition.y = hit.point.y;
            return randomPosition;
        }
        else
        {
            return GetRandomPointOnWaterSurface(center, range, retryCount + 1);
        }
    }

}

