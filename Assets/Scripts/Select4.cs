using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select4 : MonoBehaviour
{
    public void OnLoginButtonClick()
    {
        SceneManager.LoadScene("WinterIntro");
    }
}