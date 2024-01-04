using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//加载场景时需引用

public class toSpring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void B()
    {
        SceneManager.LoadScene("Spring");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
