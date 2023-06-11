using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class BtnVisual_MushRoom : MonoBehaviour
{
    private VirtualButtonBehaviour[] buttons;
    public Vector3 TreePos;
    public GameObject Bird;
    public GameObject Grass;
    private Grow grow;
    void Start()
    {
        buttons = this.GetComponentsInChildren<VirtualButtonBehaviour>();
        grow = Grass.GetComponent<Grow>();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].VirtualButtonName == "MushRoomView")
            {
                buttons[i].RegisterOnButtonPressed(MushRoomView);
            }
            else if (buttons[i].VirtualButtonName == "Plant")
            {
                buttons[i].RegisterOnButtonPressed(Plant);
            }
        }
    }

    private void MushRoomView(VirtualButtonBehaviour obj)
    {
        MushRoomView();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }
    private void Plant(VirtualButtonBehaviour obj)
    {
        Plant();
        Debug.Log(obj.VirtualButtonName + " pressed");
    }

    private void MushRoomView()
    {
        grow.PlayParticleEffect();
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        if (animals.Length > 0)
        {
            Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
        }
        else
        {
            GameObject birdInstance = Instantiate(Bird, Grass.transform.position, Quaternion.identity);
            // ��ȡBird�����BirdController���
            BirdController birdController = birdInstance.GetComponent<BirdController>();
            // ����Bird�����centerPointΪ����position
            TreePos = Grass.transform.position;
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
