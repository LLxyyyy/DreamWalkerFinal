using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutumnStar : MonoBehaviour
{
    public Move playerscore;
    private void OnParticleCollision(GameObject other)
    {
        Transform parent = gameObject.transform.parent; // 获取粒子系统对象的父物体
        if (parent != null)
        {
            Destroy(parent.gameObject); // 销毁整个父物体对象
        }
        playerscore.AddScore();

        
    }
}
