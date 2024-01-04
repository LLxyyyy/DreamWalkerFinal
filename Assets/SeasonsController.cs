using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeasonsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
