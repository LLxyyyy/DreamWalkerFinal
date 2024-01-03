using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstersCreate : MonoBehaviour
{
    // 该出生点生成的怪物
    public GameObject targetEnemy;
    // 玩家
    public GameObject player;
    // 生成怪物的总数量
    public int enemyTotalNum;
    // 生成怪物的时间间隔
    public float intervalTime = .5f;
    // 生成怪物的计数器
    public int enemyCounter;

    public GhostControl initialMonsterScript;


    // Use this for initialization
    void Start()
    {
        // 初始时，怪物计数为0；
        enemyCounter = 0;
        // 重复生成怪物
        InvokeRepeating("CreatEnemy", 0.5F, intervalTime);

        enemyTotalNum = 7;

        /*// 获取初始预制体上的脚本组件
        GhostControl initialMonsterScript = targetEnemy.GetComponent<GhostControl>();

        // 禁用初始预制体上的脚本
        initialMonsterScript.enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreatEnemy()
    {
        // 如果玩家存活
        {
            // 创建随机点在特定范围内

            float minX = -1164.5f;  // 最小X坐标
            float maxX = -1035.2f; // 最大X坐标
            float minY = 20f; // 最小Y坐标 
            float maxY = 29f; // 最大Y坐标
            float minZ = 38.2f; // 最小Z坐标
            float maxZ = 273.4f; // 最大Z坐标

            if (enemyCounter >= enemyTotalNum)
            {
                CancelInvoke("CreatEnemy");
                return;
            }

            Vector3 randomPoint = GetRandomPoint(minX, maxX, minY, maxY, minZ, maxZ);

            if (IsInWalkableArea(randomPoint))
            {
                GameObject enemy = Instantiate(targetEnemy, randomPoint, Quaternion.identity);
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                float maxHealth = 100;
                float attack1Damage = 10;
                float attack2Damage = 25;

                enemyController.Initialize(maxHealth, attack1Damage, attack2Damage);
                enemyCounter++;
            }
        }
    }

    private Vector3 GetRandomPoint(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    private bool IsInWalkableArea(Vector3 point)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(new Vector3(point.x, 100f, point.z), Vector3.down, out hitInfo, Mathf.Infinity, LayerMask.GetMask("WaterAttack")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
