using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//���س���ʱ������

public class TOspring: MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) // �����⵽�����������
        {
            SceneManager.LoadScene("Spring"); // �л�����һ������
        }
    }
}
