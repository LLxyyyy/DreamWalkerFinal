using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstersCreate : MonoBehaviour
{
    // �ó��������ɵĹ���
    public GameObject targetEnemy;
    // ���
    public GameObject player;
    // ���ɹ����������
    public int enemyTotalNum;
    // ���ɹ����ʱ����
    public float intervalTime = .5f;
    // ���ɹ���ļ�����
    public int enemyCounter;

    public GhostControl initialMonsterScript;


    // Use this for initialization
    void Start()
    {
        // ��ʼʱ���������Ϊ0��
        enemyCounter = 0;
        // �ظ����ɹ���
        InvokeRepeating("CreatEnemy", 0.5F, intervalTime);

        enemyTotalNum = 7;

        /*// ��ȡ��ʼԤ�����ϵĽű����
        GhostControl initialMonsterScript = targetEnemy.GetComponent<GhostControl>();

        // ���ó�ʼԤ�����ϵĽű�
        initialMonsterScript.enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreatEnemy()
    {
        // �����Ҵ��
        {
            // ������������ض���Χ��

            float minX = -1164.5f;  // ��СX����
            float maxX = -1035.2f; // ���X����
            float minY = 20f; // ��СY���� 
            float maxY = 29f; // ���Y����
            float minZ = 38.2f; // ��СZ����
            float maxZ = 273.4f; // ���Z����

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
