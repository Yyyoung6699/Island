using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Vector3 TreePos;
    public GameObject Bird;
    public GameObject Tree01;
    private Grow grow;
    // Start is called before the first frame update
    void Start()
    {
        grow = FindObjectOfType<Grow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play() 
    {
        grow.PlayParticleEffect();

        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        if (animals.Length > 0)
        {
            Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
        }
        else
        {
            GameObject birdInstance = Instantiate(Bird, Tree01.transform.position, Quaternion.identity);
            // ��ȡBird�����BirdController���
            BirdController birdController = birdInstance.GetComponent<BirdController>();
            // ����Bird�����centerPointΪ����position
            TreePos = Tree01.transform.position;
            birdController.SetCenterPoint(TreePos);
        }
    }
}
