using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnBack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public Transform dieUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BacktoChooseButton()
    {
        PlayerPrefs.SetInt("unlockedLevelIndex", 3);
        SceneManager.LoadScene("FourSeasons");

    }
    public void ReturnButton()
    {
        //animator.Play("Fadeout");
        dieUI.gameObject.SetActive(false);


    }
}
