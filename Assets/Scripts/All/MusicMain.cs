using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicMain : MonoBehaviour
{
    //public Slider slider;
    public AudioSource audioSource;

    private float musicStartTime; // ��¼���ֿ�ʼ���ŵ�ʱ��
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
            musicStartTime = Time.time; // ��¼���ֿ�ʼ���ŵ�ʱ��
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ��鵱ǰ�����Ƿ���Ҫ�������֣�������Ҫ���Ż�ֹͣ����
        if (scene.name == "StartTalk"|| scene.name == "FourSeasons")
        {
            // �����ƵԴ�Ƿ���ڣ�����������
            if (audioSource != null)
            {
                audioSource.Play();
                audioSource.time = Time.time - musicStartTime; // �������ֲ���ʱ�䵽֮ǰ��¼��ʱ���
            }
        }
        else
        {
            // ֹͣ����
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
