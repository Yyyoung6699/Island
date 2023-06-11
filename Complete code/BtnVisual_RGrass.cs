using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class BtnVisual_RGrass : MonoBehaviour
{
    private VirtualButtonBehaviour[] buttons;
    public Vector3 TreePos;
    public GameObject Bee;
    public GameObject Grass;
    private Grow grow;
    void Start()
    {
        buttons = this.GetComponentsInChildren<VirtualButtonBehaviour>();
        grow = Grass.GetComponent<Grow>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].VirtualButtonName == "RGrassView")
            {
                buttons[i].RegisterOnButtonPressed(RGrassView);
            }
            else if (buttons[i].VirtualButtonName == "Plant")
            {
                buttons[i].RegisterOnButtonPressed(Plant);
            }
        }
    }

    private void RGrassView(VirtualButtonBehaviour obj)
    {
        RGrassView();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }
    private void Plant(VirtualButtonBehaviour obj)
    {
        Plant();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }

    private void RGrassView()
    {
        grow.PlayParticleEffect();
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        if (animals.Length > 0)
        {
            Debug.Log("存在标记为'Animal'的对象");
        }
        else
        {
            GameObject beeInstance = Instantiate(Bee, Grass.transform.position, Quaternion.identity);
            // 获取Bird对象的BirdController组件
            BeeController beeController = beeInstance.GetComponent<BeeController>();
            // 设置Bird对象的centerPoint为树的position
            TreePos = Grass.transform.position;
            beeController.SetCenterPoint(TreePos);
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
