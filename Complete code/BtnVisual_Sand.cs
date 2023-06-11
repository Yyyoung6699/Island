using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class BtnVisual_Sand : MonoBehaviour
{
    private VirtualButtonBehaviour[] buttons;
    public Vector3 TreePos;
    public GameObject Turtle;
    public GameObject SandTree;
    private Grow grow;
    void Start()
    {
        buttons = this.GetComponentsInChildren<VirtualButtonBehaviour>();
        grow = SandTree.GetComponent<Grow>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].VirtualButtonName == "SandView")
            {
                buttons[i].RegisterOnButtonPressed(SandView);
            }
            else if (buttons[i].VirtualButtonName == "Plant")
            {
                buttons[i].RegisterOnButtonPressed(Plant);
            }
        }       
    }

    private void SandView(VirtualButtonBehaviour obj)
    {
        SandView();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }
    private void Plant(VirtualButtonBehaviour obj)
    {
        Plant();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }

    private void SandView()
    {
        grow.PlayParticleEffect();
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        if (animals.Length > 0)
        {
            Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
        }
        else
        {
            GameObject turtleInstance = Instantiate(Turtle, SandTree.transform.position, Quaternion.identity);
            // ��ȡBird�����BirdController���
            TurtleController turtleController = turtleInstance.GetComponent<TurtleController>();
            // ����Bird�����centerPointΪ����position
            TreePos = SandTree.transform.position;
            turtleController.SetCenterPoint(TreePos);
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
