using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player)
        {
            transform.position = player.position + new Vector3(0f, 4f, 0.16f);
            transform.rotation = player.rotation;
        }
    }


}
