using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutumnStar : MonoBehaviour
{
    public Move playerscore;
    private void OnParticleCollision(GameObject other)
    {
        Transform parent = gameObject.transform.parent; // ��ȡ����ϵͳ����ĸ�����
        if (parent != null)
        {
            Destroy(parent.gameObject); // �����������������
        }
        playerscore.AddScore();

        
    }
}
