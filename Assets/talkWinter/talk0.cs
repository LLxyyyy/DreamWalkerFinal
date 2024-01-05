using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk0 : MonoBehaviour
{
    public Transform talk; // ��ײ�����
    public GameObject uiObject; // UI����

    void Start()
    {
        //talk.gameObject.SetActive(false); // ��ʼ״̬�½�����ײ�����
        uiObject.SetActive(false); // ��ʼ״̬�½���UI����
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("talk")) // �����ײ���ǩ
        {
            uiObject.SetActive(true); // ����UI����
            //talk.gameObject.SetActive(true); // ������ײ�����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("talk")) // �����ײ���ǩ
        {
            uiObject.SetActive(false); // ����UI����
            //talk.gameObject.SetActive(false); // ������ײ�����
        }
    }
}