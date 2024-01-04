using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // 水面的碰撞层
    public LayerMask waterLayer;

    // 人物的碰撞体
    private Collider characterCollider;
    private Collider waterCollider;

    private void Start()
    {
        // 获取人物的碰撞体组件
        characterCollider = GetComponent<Collider>();
        // 获取水面的碰撞体组件
        waterCollider = GameObject.FindGameObjectWithTag("Water").GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (waterCollider != null)
        {
            Physics.IgnoreCollision(characterCollider, waterCollider, true);
        }
        /*// 检测人物是否在水面上
        bool isInWater = Physics.CheckBox(characterCollider.bounds.center, characterCollider.bounds.extents, transform.rotation, waterLayer);

        if (isInWater)
        {
            // 忽略人物碰撞体与水面碰撞体之间的碰撞
            Physics.IgnoreCollision(characterCollider, waterCollider, true);
        }
        else
        {
            // 不再忽略碰撞
            Physics.IgnoreCollision(characterCollider, waterCollider, false);
        }*/
    }
}
