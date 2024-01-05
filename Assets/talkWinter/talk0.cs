using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk0 : MonoBehaviour
{
    public Transform talk; // 碰撞体对象
    public GameObject uiObject; // UI对象

    void Start()
    {
        //talk.gameObject.SetActive(false); // 初始状态下禁用碰撞体对象
        uiObject.SetActive(false); // 初始状态下禁用UI对象
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("talk")) // 检查碰撞体标签
        {
            uiObject.SetActive(true); // 启用UI对象
            //talk.gameObject.SetActive(true); // 启用碰撞体对象
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("talk")) // 检查碰撞体标签
        {
            uiObject.SetActive(false); // 禁用UI对象
            //talk.gameObject.SetActive(false); // 禁用碰撞体对象
        }
    }
}