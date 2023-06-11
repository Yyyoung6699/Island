using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class BtnVisual_GGrass : MonoBehaviour
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
            if (buttons[i].VirtualButtonName == "GGrassView")
            {
                buttons[i].RegisterOnButtonPressed(GGrassView);
            }
            else if (buttons[i].VirtualButtonName == "Plant")
            {
                buttons[i].RegisterOnButtonPressed(Plant);
            }
        }
    }

    private void GGrassView(VirtualButtonBehaviour obj)
    {
        GGrassView();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }
    private void Plant(VirtualButtonBehaviour obj)
    {
        Plant();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }

    private void GGrassView()
    {
        grow.PlayParticleEffect();
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        if (animals.Length > 0)
        {
            Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
        }
        else
        {
            GameObject beeInstance = Instantiate(Bee, Grass.transform.position, Quaternion.identity);
            // ��ȡBird�����BirdController���
            BeeController beeController = beeInstance.GetComponent<BeeController>();
            // ����Bird�����centerPointΪ����position
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
