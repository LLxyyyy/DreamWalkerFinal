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
        unlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevelIndex");  //��ȡ�������ùؿ�
        levelSelectButtons = new Button[levelSelectPanel.transform.childCount];//�ؿ������ʼ��

        for (int i = 0; i < levelSelectPanel.transform.childCount; i++)//��ȡ���е�button���
        {
            levelSelectButtons[i] = levelSelectPanel.transform.GetChild(i).GetComponent<Button>();
        }

        //������button�����interactableֵ���ó�false
        for (int i = 0; i < levelSelectButtons.Length; i++)//��ȡ���е�button���
        {
            levelSelectButtons[i].interactable = false;
        }

        //������ؿ���interactable���ó�true
        for (int i = 0; i < unlockedLevelIndex + 1; i++)
        {
            levelSelectButtons[i].interactable = true;
        }
    }
}
