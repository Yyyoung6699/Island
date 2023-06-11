using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class BtnVisual_Red : MonoBehaviour
{
    private VirtualButtonBehaviour[] buttons;
    public Vector3 TreePos;
    public GameObject Deer;
    public GameObject RedTree;
    private Grow grow;
    void Start()
    {
        buttons = this.GetComponentsInChildren<VirtualButtonBehaviour>();
        grow = RedTree.GetComponent<Grow>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].VirtualButtonName == "RedView")
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
            Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
        }
        else
        {
            GameObject deerInstance = Instantiate(Deer, RedTree.transform.position, Quaternion.identity);
            // ��ȡBird�����BirdController���
            DeerController deerController = deerInstance.GetComponent<DeerController>();
            // ����Bird�����centerPointΪ����position
            TreePos = RedTree.transform.position;
            deerController.SetCenterPoint(TreePos);
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
