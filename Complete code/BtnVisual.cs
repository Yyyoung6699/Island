using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class BtnVisual : MonoBehaviour
{
    private VirtualButtonBehaviour[] buttons;
    public Vector3 TreePos;
    public GameObject Bird;
    public GameObject Tree01;
    private Grow grow;
    void Start()
    {
        buttons = this.GetComponentsInChildren<VirtualButtonBehaviour>();
        grow = Tree01.GetComponent<Grow>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].VirtualButtonName == "View")
            {
                buttons[i].RegisterOnButtonPressed(View);
            }
            else if (buttons[i].VirtualButtonName == "Plant")
            {
                buttons[i].RegisterOnButtonPressed(Plant);
            }
        }
    }

    private void View(VirtualButtonBehaviour obj)
    {
        View();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }
    private void Plant(VirtualButtonBehaviour obj)
    {
        Plant();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }

    private void View()
    {
        grow.PlayParticleEffect();
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        if (animals.Length > 0)
        {
            Debug.Log("存在标记为'Animal'的对象");
        }
        else
        {
            GameObject birdInstance = Instantiate(Bird, Tree01.transform.position, Quaternion.identity);
            // 获取Bird对象的BirdController组件
            BirdController birdController = birdInstance.GetComponent<BirdController>();
            // 设置Bird对象的centerPoint为树的position
            TreePos = Tree01.transform.position;
            birdController.SetCenterPoint(TreePos);
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
