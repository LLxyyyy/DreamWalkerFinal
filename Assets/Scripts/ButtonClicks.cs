using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClicks : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    



    public void startgame()
    {
        animator.Play("Fadeout");
        SceneManager.LoadScene("Main");
    }
    public void optionclick()
    {
        StartCoroutine(Second2OptionClick());

    }

    IEnumerator Second2OptionClick()
    {
        animator.Play("Fadeout");
        yield return  new WaitForSeconds(0.5f);
        animator2.Play("Fadein");
    }
    public void optionreturn()
    {
        StartCoroutine(Second2OptionReturnClick());
    }
    IEnumerator Second2OptionReturnClick()
    {
        animator2.Play("Fadeout");
        yield return new WaitForSeconds(0.5f);
        animator.Play("Fadein");
    }

}
