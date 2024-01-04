using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public Transform player;
    public Vector3 spawnPosition; // 怪物的出生点
    public float walkingSpeed; // 怪物在水面上的行走速度
    public float patrolRange; // 巡逻范围

    public float attackRange; // 攻击范围
    public float attackDamage; // 攻击范围
    public bool isWaitingForAttack;

    public LayerMask PlayerLayer;
    public GameObject AttackEffect;

    private Animator animator;
    private Rigidbody rb;
    public List<Vector3> patrolPoints;
    public int currentPatrolIndex = 0;

    void Start()
    {
        walkingSpeed = 5.0f; // 怪物在水面上的行走速度
        patrolRange = 20f; // 巡逻范围

        attackRange = 7f;
        attackDamage = 5f;
        isWaitingForAttack = false;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();



        spawnPosition = transform.position;

        // 实例化巡逻点列表
        patrolPoints = new List<Vector3>();
        patrolPoints.Add(spawnPosition); // 使用 Add 方法添加第一个巡逻点

        // 随机生成巡逻点
        for (int i = 0; i < 3; i++)
        {
            patrolPoints.Add(GetRandomPointOnWaterSurface(spawnPosition, patrolRange));
        }

        // 在范围内每隔 1 秒攻击一次玩家
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
        yield return new WaitForSeconds(0.3f); // 等待攻击动画完成
        if (hitEnemies.Length > 0)
        {
            Collider playerAttack = hitEnemies[0];

            // 处理攻击1伤害
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
            // 获取人物当前面向的方向
            Vector3 direction = transform.forward;
            // 将方向向前延伸 7 米
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

        // 检查怪物高度是否低于水面高度
        if (transform.position.y < 13f)
        {
            transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
        }
        Vector3 playerPosition = player.position;
        playerPosition.y = transform.position.y; // 保持在水面上的高度
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

            // 检查怪物高度是否低于水面高度
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

