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
    public float distanceUp = 30f;//�����Ŀ�����ֱ�߶Ȳ���
    public float distanceAway = 20f;//�����Ŀ���ˮƽ�������
    public float smooth = 2f;//λ��ƽ���ƶ���ֵ����ֵ
    public float camDepthSmooth = 20f;

    void Update()
    {
        /*// �������������Զ��
        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }*/
    }

    void LateUpdate()
    {
        //����������λ��
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;

        transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
        //����ĽǶ�
        transform.LookAt(target.position);
    }

}
