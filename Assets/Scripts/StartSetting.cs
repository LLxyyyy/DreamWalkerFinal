using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("unlockedLevelIndex", 0);
        //print("aaaaaaaaaa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
