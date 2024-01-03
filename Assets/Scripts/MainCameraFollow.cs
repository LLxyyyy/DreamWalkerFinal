using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{

    //public Transform Playerparent; // 父物体
    public Transform PlayerModel; // 子物体

    public Vector3 offset; // 相对位置偏移
    public Vector3 rotationoffset; // 相对位置偏移


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 8f, -7f);
        rotationoffset = new Vector3(-10f, 0f, 0f);


        if (PlayerModel != null)
        {
            // 将相机位置设置为子物体位置减去相对位置偏移
            transform.position = PlayerModel.position + offset;

            // 将相机朝向子物体
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
    // 在 LateUpdate 中更新相机位置
    void LateUpdate()
    {
        if (PlayerModel != null)
        {
            // 将相机位置设置为父物体位置加上相对位置偏移
            transform.position = PlayerModel.position + offset;

            // 将相机朝向子物体
            transform.LookAt(PlayerModel);
            transform.rotation = Quaternion.Euler(rotationoffset) * transform.rotation;
        }
    }
}
