using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//���س���ʱ������

public class TOwinter : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) // �����⵽�����������
        {
            SceneManager.LoadScene("Winter"); // �л�����һ������
        }
    }
}
