using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//加载场景时需引用

public class TOspring: MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) // 如果检测到任意键被按下
        {
            SceneManager.LoadScene("Spring"); // 切换到下一个场景
        }
    }
}
