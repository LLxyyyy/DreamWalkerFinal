using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{

    //public Transform Playerparent; // ������
    public Transform PlayerModel; // ������

    public Vector3 offset; // ���λ��ƫ��
    public Vector3 rotationoffset; // ���λ��ƫ��


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 8f, -7f);
        rotationoffset = new Vector3(-10f, 0f, 0f);


        if (PlayerModel != null)
        {
            // �����λ������Ϊ������λ�ü�ȥ���λ��ƫ��
            transform.position = PlayerModel.position + offset;

            // ���������������
            //Vector3 lookDirection = PlayerModel.forward;
            //transform.rotation = Quaternion.LookRotation(lookDirection);
            transform.LookAt(PlayerModel);
            transform.rotation = Quaternion.Euler(rotationoffset) * transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // �� LateUpdate �и������λ��
    void LateUpdate()
    {
        if (PlayerModel != null)
        {
            // �����λ������Ϊ������λ�ü������λ��ƫ��
            transform.position = PlayerModel.position + offset;

            // ���������������
            transform.LookAt(PlayerModel);
            transform.rotation = Quaternion.Euler(rotationoffset) * transform.rotation;
        }
    }
}
