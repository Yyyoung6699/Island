using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteraction : MonoBehaviour
{
    private Camera cam;

    public float smooth = 3f;
    Transform currentObject;
    Vector3 mouse3DPosition;
    public Vector3 TreePos;

    public GameObject Monkey;
    public GameObject Bee;
    public GameObject Turtle;
    public GameObject Deer;
    public GameObject Bird;//�Ѿ�����˰���BirdController�Ľű�

    public TreeSpawn treeSpawn;//���ýű�
    public GrassSpawn grassSpawn;
    public Grow growleave;//���ýű�

    public BtnMouse btnMouse;
    int Mousezhuangtai;//���

    private int previousTrees = 0;
    private int previousGrass = 0;
    public int Score = 0;//����
    private UIshow uishow;
    // Start is called before the first frame update
    void Start()
    {
        btnMouse = FindObjectOfType<BtnMouse>();//���
        cam = GameObject.FindWithTag("ARCamera").GetComponent<Camera>();
        grassSpawn = FindObjectOfType<GrassSpawn>();
        treeSpawn = FindObjectOfType<TreeSpawn>();//���ýű�
        //growleave = FindObjectOfType<Grow>();//���ýű�
    }

    // Update is called once per frame
    void Update()
    {
        Mousezhuangtai = btnMouse.MouseZhuangtai;//���״̬
        if (Input.GetMouseButtonUp(0) && Mousezhuangtai == 0)
        {
            RayCast();
        }
    }

    void RayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.CompareTag("GreenTree"))
            {
                Score = Score + 1;
                currentObject = hit.transform;
                Debug.Log(currentObject.name);
                Debug.Log(currentObject.position);
                growleave = currentObject.GetComponent<Grow>();
                growleave.PlayParticleEffect();
                Debug.Log("����");
                // ���ȫ���Ƿ���ڱ��Ϊ"Animal"�Ķ���
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
                }
                else
                {
                    //InsBird();
                }
            }
            if (hit.collider.CompareTag("RedTree"))
            {
                Score = Score + 1;
                currentObject = hit.transform;
                Debug.Log(currentObject.name);
                Debug.Log(currentObject.position);
                growleave = currentObject.GetComponent<Grow>();
                growleave.PlayParticleEffect();
                // ���ȫ���Ƿ���ڱ��Ϊ"Animal"�Ķ���
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
                }
                else
                {
                    //InsDeer();
                }
            }
            if (hit.collider.CompareTag("SandTree"))
            {
                Score = Score + 1;
                currentObject = hit.transform;
                Debug.Log(currentObject.name);
                Debug.Log(currentObject.position);
                growleave = currentObject.GetComponent<Grow>();
                growleave.PlayParticleEffect();
                // ���ȫ���Ƿ���ڱ��Ϊ"Animal"�Ķ���
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
                }
                else
                {
                    //InsTurtle();
                }
            }
            //if (hit.collider.CompareTag("SnowTree"))
            //{
            //    Score = Score + 1;
            //    currentObject = hit.transform;
            //    Debug.Log(currentObject.name);
            //    Debug.Log(currentObject.position);
            //    growleave = currentObject.GetComponent<Grow>();
            //    growleave.PlayParticleEffect();
            //    // ���ȫ���Ƿ���ڱ��Ϊ"Animal"�Ķ���
            //    GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
            //    if (animals.Length > 0)
            //    {
            //        Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
            //    }
            //    else
            //    {
            //        GameObject[] MushRoom = GameObject.FindGameObjectsWithTag("MushRoom");
            //        if (MushRoom.Length > 0)
            //        {
            //            InsMonkey();
            //        }
            //        else
            //        {
            //            uishow = FindObjectOfType<UIshow>();
            //            StartCoroutine(ExecuteFadeOutAfterDelay());
            //            //uishow.UI_FadeIn_Event();
            //            //uishow.UI_FadeOut_Event()
            //        }
            //    }
            //}
        }
    }
    //private IEnumerator ExecuteFadeOutAfterDelay()
    //{
    //    // ִ��FadeIn
    //    uishow.UI_FadeIn_Event();
    //    // �ȴ�2��
    //    yield return new WaitForSeconds(2f);
    //    // ִ��FadeOut
    //    uishow.UI_FadeOut_Event();
    //}
    //void InsBird()
    //{
    //    int greenTrees = treeSpawn.GreenTrees;
    //    if (Random.value < 0.01f * greenTrees)
    //    {
    //        // ����Bird����
    //        GameObject birdInstance = Instantiate(Bird, currentObject.position, Quaternion.identity);
    //        // ��ȡBird�����BirdController���
    //        BirdController birdController = birdInstance.GetComponent<BirdController>();
    //        // ����Bird�����centerPointΪ����position
    //        TreePos = currentObject.position;
    //        birdController.SetCenterPoint(TreePos);
    //        //ÿ����һֻ�񣬿���ֲ����+5
    //        treeSpawn.IncreasePlantNum(5);
    //        Score = Score + 100;
    //    }
    //}
    //void InsDeer()
    //{
    //    int redTrees = treeSpawn.RedTrees;
    //    if (Random.value < 0.01f * redTrees)
    //    {
    //        GameObject DeerInstance = Instantiate(Deer, currentObject.position, Quaternion.identity);
    //        DeerController deerController = DeerInstance.GetComponent<DeerController>();
    //        TreePos = currentObject.position;
    //        deerController.SetCenterPoint(TreePos);
    //        treeSpawn.IncreasePlantNum(5);
    //        Score = Score + 100;
    //    }
    //}
    //void InsTurtle()
    //{
    //    int SandTrees = treeSpawn.SandTrees;
    //    if (Random.value < 0.01f * SandTrees)
    //    {
    //        GameObject TurtleInstance = Instantiate(Turtle, currentObject.position, Quaternion.identity);
    //        TurtleController turtleController = TurtleInstance.GetComponent<TurtleController>();
    //        TreePos = currentObject.position;
    //        turtleController.SetCenterPoint(TreePos);
    //        treeSpawn.IncreasePlantNum(5);
    //        Score = Score + 100;
    //    }
    //}
    //void InsMonkey()
    //{
    //    int SnowTrees = treeSpawn.SnowTrees;
    //    Vector3 Monkeypos = new Vector3(currentObject.position.x + 5f, currentObject.position.y, currentObject.position.z + 5f);
    //    if (Random.value < 0.05f * SnowTrees)
    //    {
    //        GameObject MonkeyInstance = Instantiate(Monkey, Monkeypos, Quaternion.identity);
    //        MonkeyController monkeyController = MonkeyInstance.GetComponent<MonkeyController>();
    //        TreePos = currentObject.position;
    //        monkeyController.SetCenterPoint(TreePos);
    //        treeSpawn.IncreasePlantNum(5);
    //        Score = Score + 500;
    //    }
    //}
}
