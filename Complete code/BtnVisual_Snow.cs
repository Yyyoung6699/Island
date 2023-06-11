using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class BtnVisual_Snow : MonoBehaviour
{
    private VirtualButtonBehaviour[] buttons;
    public Vector3 TreePos;
    public GameObject Monkey;
    public GameObject SnowTree;
    private Grow grow;
    void Start()
    {
        buttons = this.GetComponentsInChildren<VirtualButtonBehaviour>();
        grow = SnowTree.GetComponent<Grow>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].VirtualButtonName == "SnowView")
            {
                buttons[i].RegisterOnButtonPressed(SnowView);
            }
            else if (buttons[i].VirtualButtonName == "Plant")
            {
                buttons[i].RegisterOnButtonPressed(Plant);
            }
        }
    }

    private void SnowView(VirtualButtonBehaviour obj)
    {
        SnowView();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }
    private void Plant(VirtualButtonBehaviour obj)
    {
        Plant();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }

    private void SnowView()
    {
        grow.PlayParticleEffect();
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        if (animals.Length > 0)
        {
            Debug.Log("存在标记为'Animal'的对象");
        }
        else
        {
            Vector3 Monkeypos = new Vector3(SnowTree.transform.position.x + 5f, SnowTree.transform.position.y, SnowTree.transform.position.z + 5f);
            GameObject monkeyInstance = Instantiate(Monkey, Monkeypos, Quaternion.identity);
            // 获取Bird对象的BirdController组件
            MonkeyController monkeyController = monkeyInstance.GetComponent<MonkeyController>();
            // 设置Bird对象的centerPoint为树的position
            TreePos = SnowTree.transform.position;
            monkeyController.SetCenterPoint(TreePos);
        }
    }
    private void Plant()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {

    }
}
