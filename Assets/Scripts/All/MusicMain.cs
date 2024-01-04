using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicMain : MonoBehaviour
{
    //public Slider slider;
    public AudioSource audioSource;

    private float musicStartTime; // 记录音乐开始播放的时间
    // Start is called before the first frame update

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {


        SceneManager.sceneLoaded += OnSceneLoaded;
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            musicStartTime = Time.time; // 记录音乐开始播放的时间
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 检查当前场景是否需要播放音乐，根据需要播放或停止音乐
        if (scene.name == "StartTalk"|| scene.name == "FourSeasons")
        {
            // 检查音频源是否存在，并播放音乐
            if (audioSource != null)
            {
                audioSource.Play();
                audioSource.time = Time.time - musicStartTime; // 设置音乐播放时间到之前记录的时间点
            }
        }
        else
        {
            // 停止音乐
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
    // Update is called once per frame
/*    void Update()
    {
        Volume();
    }*/
    /*public void Volume()
    {
        audioSource.volume = slider.value / 100;

    }*/
}
