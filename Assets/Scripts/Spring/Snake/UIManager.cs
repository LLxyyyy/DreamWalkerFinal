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
    //public Transform dieUI;//��Ϸʧ�����
    public int score;
    public Animator animator;
    public Animator animator2;

    public Transform dieui;

    public Transform dieui2;

    public bool flag1 = false;

    void Start()
    {
        //��ʼ��
        uiMagr = this;
        dieui.gameObject.SetActive(false);
        dieui2.gameObject.SetActive(false);
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
            flag1 = true;
            PlayerPrefs.SetInt("unlockedLevelIndex", 1);
            dieui2.gameObject.SetActive(true);
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
        dieui.gameObject.SetActive(true);
        if(!flag1)
        {
            dieui2.gameObject.SetActive(false);
        }
        else
        {
            dieui2.gameObject.SetActive(true);
        }

    }

    //ˢ��
    void Refresh()
    {
        //���¼��س���
        SceneManager.LoadScene("SnakePlay");
    }
}
