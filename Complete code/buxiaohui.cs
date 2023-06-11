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
        Transform canvas = GameObject.Find("Icon").transform; // 获取Canvas对象的Transform组件
        

        if (canvas != null)
        {
            transform.SetParent(canvas); // 设置当前对象的父级为IconCollection
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
