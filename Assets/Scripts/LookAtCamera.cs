using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera mainCamera; // 拖拽摄像机对象到该变量中

    void LateUpdate()
    {
        transform.LookAt(mainCamera.transform.position);
    }
}
