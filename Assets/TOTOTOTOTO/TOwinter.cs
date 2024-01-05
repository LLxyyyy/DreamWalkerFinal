using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//加载场景时需引用

public class TOwinter : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) // 如果检测到任意键被按下
        {
            SceneManager.LoadScene("Winter"); // 切换到下一个场景
        }
    }
}
