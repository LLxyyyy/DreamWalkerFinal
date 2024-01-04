using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;//加载场景时需引用

public class UIManager : MonoBehaviour
{
    public static UIManager uiMagr;
    public Text number_txt;//分数
    public Button refreshBtn;//重新开始按钮
    //public Transform dieUI;//游戏失败面板
    public int score;
    public Animator animator;
    public Animator animator2;

    public Transform dieui;

    public Transform dieui2;

    public bool flag1 = false;

    void Start()
    {
        //初始化
        uiMagr = this;
        dieui.gameObject.SetActive(false);
        dieui2.gameObject.SetActive(false);
        refreshBtn.onClick.AddListener(Refresh);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //按下esc 退出程序
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

    //修改分数值
    public void SetNumber(int value)
    {
        number_txt.text = value.ToString();
        score = value;
    }

    //显示死亡UI
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

    //刷新
    void Refresh()
    {
        //重新加载场景
        SceneManager.LoadScene("SnakePlay");
    }
}
