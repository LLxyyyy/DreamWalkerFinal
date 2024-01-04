using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHead : MonoBehaviour
{/*public Transform player;
    public Vector3 distance = new Vector3(0f,4f,-7.8f);
    public float speed;
    Vector3 ve;
    void Start()
    {
        distance = new Vector3(0f, 4f, -7.8f);
    //distance = transform.position - player.position;
}
    void Update()
    {
        transform.localPosition = player.localPosition + distance;
        transform.localRotation = player.localRotation;
        //transform.rotation = player.rotation;
        //transform.position = player.position + distance;
        Debug.Log(distance);
        Debug.Log(player.position);
        Debug.Log(transform.position);
    }
*/
    public Transform target;
    public float distanceUp = 30f;//相机与目标的竖直高度参数
    public float distanceAway = 20f;//相机与目标的水平距离参数
    public float smooth = 2f;//位置平滑移动插值参数值
    public float camDepthSmooth = 20f;

    void Update()
    {
        /*// 鼠标轴控制相机的远近
        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }*/
    }

    void LateUpdate()
    {
        //计算出相机的位置
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;

        transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
        //相机的角度
        transform.LookAt(target.position);
    }

}
