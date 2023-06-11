using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
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

    public Text text;
    private int previousTrees = 0;
    private int previousGrass = 0;
    public int Score = 0;//����
    private UIshow uishow;

    private Color savedColor4;
    private Color savedColor3;
    private Color savedColor2;
    private Color savedColor1;
    // Start is called before the first frame update
    void Start()
    {
        btnMouse = FindObjectOfType<BtnMouse>();//���
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        grassSpawn = FindObjectOfType<GrassSpawn>();
        treeSpawn = FindObjectOfType<TreeSpawn>();//���ýű�
        //growleave = FindObjectOfType<Grow>();//���ýű�

        if (PlayerPrefs.HasKey("ImageColor4"))
        {
            string colorString = PlayerPrefs.GetString("ImageColor4");
            ColorUtility.TryParseHtmlString(colorString, out savedColor4);
            SetImageColor4(savedColor4);
        }
        if (PlayerPrefs.HasKey("ImageColor3"))
        {
            string colorString = PlayerPrefs.GetString("ImageColor3");
            ColorUtility.TryParseHtmlString(colorString, out savedColor3);
            SetImageColor3(savedColor3);
        }
        if (PlayerPrefs.HasKey("ImageColor2"))
        {
            string colorString = PlayerPrefs.GetString("ImageColor2");
            ColorUtility.TryParseHtmlString(colorString, out savedColor2);
            SetImageColor2(savedColor2);
        }
        if (PlayerPrefs.HasKey("ImageColor1"))
        {
            string colorString = PlayerPrefs.GetString("ImageColor1");
            ColorUtility.TryParseHtmlString(colorString, out savedColor1);
            SetImageColor1(savedColor1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Mousezhuangtai = btnMouse.MouseZhuangtai;//���״̬
        if (Input.GetMouseButtonUp(0) && Mousezhuangtai == 0)
        {
            RayCast();
        }
        if (treeSpawn.Trees != previousTrees)
        {
            Score = (treeSpawn.Trees - previousTrees) * 20 + Score;
            previousTrees = treeSpawn.Trees;
        }
        if (grassSpawn.GrassScore != previousGrass)
        {
            Score = (grassSpawn.GrassScore - previousGrass) + Score;
            previousGrass = grassSpawn.GrassScore;
        }
        text.text = Score.ToString();

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
                // ���ȫ���Ƿ���ڱ��Ϊ"Animal"�Ķ���
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("���ڱ��Ϊ'Animal'�Ķ���");
                }
                else
                {
                    InsBird();
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
                    InsDeer();
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
                    InsTurtle();
                }
            }
            if (hit.collider.CompareTag("SnowTree"))
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
                    GameObject[] MushRoom = GameObject.FindGameObjectsWithTag("MushRoom");
                    if (MushRoom.Length > 0)
                    {
                        InsMonkey();
                    }
                    else
                    {
                        uishow = FindObjectOfType<UIshow>();
                        StartCoroutine(ExecuteFadeOutAfterDelay());
                        //uishow.UI_FadeIn_Event();
                        //uishow.UI_FadeOut_Event()
                    }
                }
            }
        }
    }
    private IEnumerator ExecuteFadeOutAfterDelay()
    {
        // ִ��FadeIn
        uishow.UI_FadeIn_Event();
        // �ȴ�2��
        yield return new WaitForSeconds(2f);
        // ִ��FadeOut
        uishow.UI_FadeOut_Event();
    }
    void InsBird()
    {
        GameObject[] GreenTree = GameObject.FindGameObjectsWithTag("GreenTree");
        //int greenTrees = treeSpawn.GreenTrees;
        if (Random.value < 0.01f * GreenTree.Length)
        {
            // ����Bird����
            GameObject birdInstance = Instantiate(Bird, currentObject.position, Quaternion.identity);
            // ��ȡBird�����BirdController���
            BirdController birdController = birdInstance.GetComponent<BirdController>();
            // ����Bird�����centerPointΪ����position
            TreePos = currentObject.position;
            birdController.SetCenterPoint(TreePos);
            //ÿ����һֻ�񣬿���ֲ����+5
            treeSpawn.IncreasePlantNum(5);
            Score = Score + 100;
            // ����ͼƬ�� Alpha ֵΪ 255
            Image image4 = GameObject.Find("Image (4)").GetComponent<Image>();
            Color color = image4.color;
            color.a = 1f; // ���� Alpha ֵΪ 1��255 / 255��
            image4.color = color;

            savedColor4 = image4.color;
            PlayerPrefs.SetString("ImageColor4", ColorUtility.ToHtmlStringRGBA(savedColor4));

        }
    }
    void InsDeer()
    {
        GameObject[] RedTree = GameObject.FindGameObjectsWithTag("RedTree");
        //int redTrees = treeSpawn.RedTrees;
        if (Random.value < 0.01f * RedTree.Length)
        {
            GameObject DeerInstance = Instantiate(Deer, currentObject.position, Quaternion.identity);
            DeerController deerController = DeerInstance.GetComponent<DeerController>();
            TreePos = currentObject.position;
            deerController.SetCenterPoint(TreePos);            
            treeSpawn.IncreasePlantNum(5);
            Score = Score + 100;
            // ����ͼƬ�� Alpha ֵΪ 255
            Image image3 = GameObject.Find("Image (3)").GetComponent<Image>();
            Color color = image3.color;
            color.a = 1f; // ���� Alpha ֵΪ 1��255 / 255��
            image3.color = color;

            savedColor3 = image3.color;
            PlayerPrefs.SetString("ImageColor3", ColorUtility.ToHtmlStringRGBA(savedColor3));
        }
    }
    void InsTurtle()
    {
        GameObject[] SandTree = GameObject.FindGameObjectsWithTag("SandTree");
        //int SandTrees = treeSpawn.SandTrees;
        if (Random.value < 0.01f * SandTree.Length)
        {
            GameObject TurtleInstance = Instantiate(Turtle, currentObject.position, Quaternion.identity);
            TurtleController turtleController = TurtleInstance.GetComponent<TurtleController>();
            TreePos = currentObject.position;
            turtleController.SetCenterPoint(TreePos);
            treeSpawn.IncreasePlantNum(5);
            Score = Score + 100;
            // ����ͼƬ�� Alpha ֵΪ 255
            Image image2 = GameObject.Find("Image (2)").GetComponent<Image>();
            Color color = image2.color;
            color.a = 1f; // ���� Alpha ֵΪ 1��255 / 255��
            image2.color = color;
            //ColorManager.AlphaValue = image4.color;

            savedColor2 = image2.color;
            PlayerPrefs.SetString("ImageColor2", ColorUtility.ToHtmlStringRGBA(savedColor2));
        }
    }
    void InsMonkey()
    {
        GameObject[] SnowTree = GameObject.FindGameObjectsWithTag("SnowTree");
        //int SnowTrees = treeSpawn.SnowTrees;
        Vector3 Monkeypos = new Vector3(currentObject.position.x+5f, currentObject.position.y, currentObject.position.z+5f);
        if (Random.value < 0.01f * SnowTree.Length)
        {
            GameObject MonkeyInstance = Instantiate(Monkey, Monkeypos, Quaternion.identity);
            MonkeyController monkeyController = MonkeyInstance.GetComponent<MonkeyController>();
            TreePos = currentObject.position;
            monkeyController.SetCenterPoint(TreePos);
            treeSpawn.IncreasePlantNum(5);
            Score = Score + 500;
            // ����ͼƬ�� Alpha ֵΪ 255
            Image image1 = GameObject.Find("Image").GetComponent<Image>();
            Color color = image1.color;
            color.a = 1f; // ���� Alpha ֵΪ 1��255 / 255��
            image1.color = color;

            savedColor1 = image1.color;
            PlayerPrefs.SetString("ImageColor1", ColorUtility.ToHtmlStringRGBA(savedColor1));
        }
    }
    void SetImageColor4(Color color)
    {
        Image image4 = GameObject.Find("Image (4)").GetComponent<Image>();
        image4.color = color;
    }
    void SetImageColor3(Color color)
    {
        Image image3 = GameObject.Find("Image (3)").GetComponent<Image>();
        image3.color = color;
    }
    void SetImageColor2(Color color)
    {
        Image image2 = GameObject.Find("Image (2)").GetComponent<Image>();
        image2.color = color;
    }
    void SetImageColor1(Color color)
    {
        Image image1 = GameObject.Find("Image").GetComponent<Image>();
        image1.color = color;
    }
}
