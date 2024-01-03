using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab; // �����Ԥ����
    public Transform spawnPoint; // ����ĳ�����
    public float spawnInterval = 1f; // ��������ļ��ʱ��
    public int maxGhosts = 10; // ����������
    public float wanderRadius = 10f; // ��������ߵİ뾶

    private List<GameObject> ghosts = new List<GameObject>(); // �Ѵ����Ĺ����б�
    private float timer = 0f; // ��ʱ��

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && ghosts.Count < maxGhosts)
        {
            timer = 0f;
            SpawnGhost();
        }

        for (int i = ghosts.Count - 1; i >= 0; i--)
        {
            if (ghosts[i] == null)
            {
                ghosts.RemoveAt(i);
            }
        }
    }

    void SpawnGhost()
    {
        Vector3 randomSpawnPoint = GetRandomSpawnPoint();
        Vector3 validSpawnPoint;
        if (NavMesh.SamplePosition(randomSpawnPoint, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
        {
            validSpawnPoint = hit.position;
        }
        else
        {
            validSpawnPoint = randomSpawnPoint;
        }
        GameObject newGhost = Instantiate(ghostPrefab, GetRandomPointAround(validSpawnPoint, wanderRadius), Quaternion.identity);
        ghosts.Add(newGhost);
    }


    Vector3 GetRandomSpawnPoint()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
        return new Vector3(spawnPoint.position.x + randomPoint.x, spawnPoint.position.y, spawnPoint.position.z + randomPoint.y);
    }

    Vector3 GetRandomPointAround(Vector3 center, float range)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * range;
        return new Vector3(center.x + randomPoint.x, center.y, center.z + randomPoint.y);
    }
}
