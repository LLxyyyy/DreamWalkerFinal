using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//加载场景时需引用

public class toend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void A()
    {
        SceneManager.LoadScene("gameover");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
