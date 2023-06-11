using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buxiaohui : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Transform canvas = GameObject.Find("Icon").transform; // ��ȡCanvas�����Transform���
        

        if (canvas != null)
        {
            transform.SetParent(canvas); // ���õ�ǰ����ĸ���ΪIconCollection
        }
        else
        {
            Debug.LogError("IconCollection not found!");
        }
    }

    void Update()
    {

    }
}
