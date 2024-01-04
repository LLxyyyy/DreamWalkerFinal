using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//���س���ʱ������

public class UIManager : MonoBehaviour
{
    public static UIManager uiMagr;
    public Text number_txt;//����
    public Button refreshBtn;//���¿�ʼ��ť
    public Transform dieUI;//��Ϸʧ�����
    public int score;

    void Start()
    {
        //��ʼ��
        uiMagr = this;
        dieUI.gameObject.SetActive(false);
        refreshBtn.onClick.AddListener(Refresh);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //����esc �˳�����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(score == 2)
        {
            PlayerPrefs.SetInt("unlockedLevelIndex", 1);
            SceneManager.LoadScene("FourSeasons");
        }

    }

    //�޸ķ���ֵ
    public void SetNumber(int value)
    {
        number_txt.text = value.ToString();
        score = value;
    }

    //��ʾ����UI
    public void DieUI()
    {
        dieUI.gameObject.SetActive(true);
    }

    //ˢ��
    void Refresh()
    {
        //���¼��س���
        SceneManager.LoadScene("SnakePlay");
    }
}
