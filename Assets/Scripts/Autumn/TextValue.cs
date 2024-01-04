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

    void Update()
    {
        score = targetScript.score;
        textComponent.text = score.ToString();
        if(score == 2)
        {
            animator.Play("Fadein");
        }
    }
}
