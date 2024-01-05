using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//加载场景时需引用

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BacktoChoose()
    {
        SceneManager.LoadScene("FourSeasons"); // 切换到下一个场景
    }
    public void Over1()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
