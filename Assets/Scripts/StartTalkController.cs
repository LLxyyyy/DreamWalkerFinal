using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTalkController : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown) // 如果检测到任意键被按下
        {
            SceneManager.LoadScene("FourSeasons"); // 切换到下一个场景
        }
    }
}
