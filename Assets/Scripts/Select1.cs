using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select1 : MonoBehaviour
{
    public void OnLoginButtonClick()
    {
        Debug.Log("1925");
        SceneManager.LoadScene("SpringIntro");
    }
}