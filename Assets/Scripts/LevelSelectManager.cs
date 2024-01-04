using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject levelSelectPanel;
    Button[] levelSelectButtons;
    int unlockedLevelIndex;

    // Start is called before the first frame update
    void Start()
    {
        unlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevelIndex");  //获取解锁过得关卡
        levelSelectButtons = new Button[levelSelectPanel.transform.childCount];//关卡数组初始化

        for (int i = 0; i < levelSelectPanel.transform.childCount; i++)//获取所有的button组件
        {
            levelSelectButtons[i] = levelSelectPanel.transform.GetChild(i).GetComponent<Button>();
        }

        //将所有button组件的interactable值设置成false
        for (int i = 0; i < levelSelectButtons.Length; i++)//获取所有的button组件
        {
            levelSelectButtons[i].interactable = false;
        }

        //解锁后关卡的interactable设置成true
        for (int i = 0; i < unlockedLevelIndex + 1; i++)
        {
            levelSelectButtons[i].interactable = true;
        }
    }
}
