using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//���س���ʱ������

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
        SceneManager.LoadScene("FourSeasons"); // �л�����һ������
    }
    public void Over1()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
