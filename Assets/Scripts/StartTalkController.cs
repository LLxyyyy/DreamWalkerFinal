using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTalkController : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown) // �����⵽�����������
        {
            SceneManager.LoadScene("FourSeasons"); // �л�����һ������
        }
    }
}
