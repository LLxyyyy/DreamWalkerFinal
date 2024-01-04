using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // ˮ�����ײ��
    public LayerMask waterLayer;

    // �������ײ��
    private Collider characterCollider;
    private Collider waterCollider;

    private void Start()
    {
        // ��ȡ�������ײ�����
        characterCollider = GetComponent<Collider>();
        // ��ȡˮ�����ײ�����
        waterCollider = GameObject.FindGameObjectWithTag("Water").GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (waterCollider != null)
        {
            Physics.IgnoreCollision(characterCollider, waterCollider, true);
        }
        /*// ��������Ƿ���ˮ����
        bool isInWater = Physics.CheckBox(characterCollider.bounds.center, characterCollider.bounds.extents, transform.rotation, waterLayer);

        if (isInWater)
        {
            // ����������ײ����ˮ����ײ��֮�����ײ
            Physics.IgnoreCollision(characterCollider, waterCollider, true);
        }
        else
        {
            // ���ٺ�����ײ
            Physics.IgnoreCollision(characterCollider, waterCollider, false);
        }*/
    }
}
