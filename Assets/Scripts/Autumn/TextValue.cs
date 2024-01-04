using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextValue : MonoBehaviour
{
    public Text textComponent;
    int score = 0;
    public Move targetScript;
    public Animator animator;



    public bool flag = false;

    void Update()
    {
        score = targetScript.score;
        textComponent.text = score.ToString();
        if(score == 2&&!flag)
        {
            flag = true;
            //PlayerPrefs.SetInt("unlockedLevelIndex", 3);
            animator.Play("Fadein");
        }
    }
}
