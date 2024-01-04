using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSlider : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;


    void Start()
    {
        slider.value = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        Volume();
    }
    public void Volume()
    {
        audioSource.volume = slider.value / 100;

    }
}
