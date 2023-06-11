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
    public GameObject Bird;//已经添加了包含BirdController的脚本

    public TreeSpawn treeSpawn;//调用脚本
    public GrassSpawn grassSpawn;
    public Grow growleave;//调用脚本

    public BtnMouse btnMouse;
    int Mousezhuangtai;//鼠标

    private int previousTrees = 0;
    private int previousGrass = 0;
    public int Score = 0;//分数
    private UIshow uishow;
    // Start is called before the first frame update
    void Start()
    {
        btnMouse = FindObjectOfType<BtnMouse>();//鼠标
        cam = GameObject.FindWithTag("ARCamera").GetComponent<Camera>();
        grassSpawn = FindObjectOfType<GrassSpawn>();
        treeSpawn = FindObjectOfType<TreeSpawn>();//调用脚本
        //growleave = FindObjectOfType<Grow>();//调用脚本
    }

    // Update is called once per frame
    void Update()
    {
        Mousezhuangtai = btnMouse.MouseZhuangtai;//鼠标状态
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
                Debug.Log("播放");
                // 检查全局是否存在标记为"Animal"的对象
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("存在标记为'Animal'的对象");
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
                // 检查全局是否存在标记为"Animal"的对象
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("存在标记为'Animal'的对象");
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
                // 检查全局是否存在标记为"Animal"的对象
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("存在标记为'Animal'的对象");
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
            //    // 检查全局是否存在标记为"Animal"的对象
            //    GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
            //    if (animals.Length > 0)
            //    {
            //        Debug.Log("存在标记为'Animal'的对象");
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
    //    // 执行FadeIn
    //    uishow.UI_FadeIn_Event();
    //    // 等待2秒
    //    yield return new WaitForSeconds(2f);
    //    // 执行FadeOut
    //    uishow.UI_FadeOut_Event();
    //}
    //void InsBird()
    //{
    //    int greenTrees = treeSpawn.GreenTrees;
    //    if (Random.value < 0.01f * greenTrees)
    //    {
    //        // 创建Bird对象
    //        GameObject birdInstance = Instantiate(Bird, currentObject.position, Quaternion.identity);
    //        // 获取Bird对象的BirdController组件
    //        BirdController birdController = birdInstance.GetComponent<BirdController>();
    //        // 设置Bird对象的centerPoint为树的position
    //        TreePos = currentObject.position;
    //        birdController.SetCenterPoint(TreePos);
    //        //每生成一只鸟，可种植的树+5
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
