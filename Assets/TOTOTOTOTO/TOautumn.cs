using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//���س���ʱ������
public class TOautumn : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.anyKeyDown) // �����⵽�����������
        {
            SceneManager.LoadScene("Autumn"); // �л�����һ������
        }
    }
}
