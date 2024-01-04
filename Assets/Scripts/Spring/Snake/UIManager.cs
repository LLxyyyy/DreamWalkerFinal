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

    void Start()
    {
        //��ʼ��
        uiMagr = this;
        dieUI.gameObject.SetActive(false);
        refreshBtn.onClick.AddListener(Refresh);
    }

    // Update is called once per frame
    void Update()
    {
        //����esc �˳�����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //�޸ķ���ֵ
    public void SetNumber(int value)
    {
        number_txt.text = value.ToString();
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
