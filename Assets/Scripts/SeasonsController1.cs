using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SeasonsController1 : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Button spring;
    public UnityEngine.UI.Button summer;
    public UnityEngine.UI.Button autumn;
    public UnityEngine.UI.Button winter;
    void Start()
    {
        spring.interactable = true;
        summer.interactable = false;
        autumn.interactable = false;
        winter.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpringClick()
    {
        SceneManager.LoadScene("Spring");
    }
    public void SummerClick()
    {
        SceneManager.LoadScene("Summer");
    }
    public void AutumnClick()
    {
        SceneManager.LoadScene("Autumn");
    }
    public void WinterClick()
    {
        SceneManager.LoadScene("Winter");
    }

}
