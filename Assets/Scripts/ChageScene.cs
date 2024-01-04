using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//场景头部引入

public class ChageScene : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("Start"))
        {
            return;
        }
        SceneManager.LoadScene("Start");
    }


}
