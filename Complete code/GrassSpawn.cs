using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrassSpawn : MonoBehaviour
{
    private Camera cam;
    public GameObject[] GrassGrass;
    public GameObject[] RedGrass;
    public GameObject[] SnowGrass;

    [SerializeField] Material mat;
    int triangleIdx;
    Mesh mesh;
    int subMeshesNr;
    int matI = -1;
    Renderer rend;
    MeshCollider meshCollider;
    Ray ray;

    public float rayMoveUpDistance = 50f;
    public int BrushSize = 40;

    public BtnMouse btnMouse;
    int Mousezhuangtai;//���

    public int Grass = 0;

    public TreeSpawn treeSpawn;//���ýű�
    public GameObject Bee;
    public Vector3 TreePos;

    string arImage;
    public int GrassScore;

    public AudioClip Sound;
    private AudioSource audioSource;
    private UIshow2 uishow2;

    private Color savedColor5;
    // Start is called before the first frame update
    void Start()
    {
        btnMouse = FindObjectOfType<BtnMouse>();//���
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        treeSpawn = FindObjectOfType<TreeSpawn>();//���ýű�

        audioSource = GetComponent<AudioSource>();
        uishow2 = FindObjectOfType<UIshow2>();

        if (PlayerPrefs.HasKey("ImageColor5"))
        {
            string colorString = PlayerPrefs.GetString("ImageColor5");
            ColorUtility.TryParseHtmlString(colorString, out savedColor5);
            SetBeeIcon(savedColor5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Mousezhuangtai = btnMouse.MouseZhuangtai;//���״̬
        if (Input.GetMouseButton(0) && Mousezhuangtai == 2)
        {
            RayCast();
        }
        arImage = DefaultObserverEventHandler.ArImage;//��ȡAR��Ϣ
    }

    void RayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Vector3 hitPos = hit.point;
                MeshCollider meshCollider = hit.collider as MeshCollider;
                if (meshCollider != null || meshCollider.sharedMesh != null)
                {
                    mesh = meshCollider.sharedMesh;
                    Renderer renderer = hit.collider.GetComponent<MeshRenderer>();

                    int[] hitTriangle = new int[]
                    {
                        mesh.triangles[hit.triangleIndex * 3],
                        mesh.triangles[hit.triangleIndex * 3 + 1],
                        mesh.triangles[hit.triangleIndex * 3 + 2]
                    };
                    for (int i = 0; i < mesh.subMeshCount; i++)
                    {
                        int[] subMeshTris = mesh.GetTriangles(i);
                        for (int j = 0; j < subMeshTris.Length; j += 3)
                        {
                            if (subMeshTris[j] == hitTriangle[0] &&
                                subMeshTris[j + 1] == hitTriangle[1] &&
                                subMeshTris[j + 2] == hitTriangle[2])
                            {
                                mat = renderer.materials[i];

                                Debug.Log(i);


                                if (i == 3)
                                {
                                    //���������
                                    float randomX = Random.Range(-BrushSize / 2, BrushSize / 2);
                                    float randomZ = Random.Range(-BrushSize / 2, BrushSize / 2);

                                    //����������ƶ�100m�����´�������
                                    Vector3 readySpawnPoints = new Vector3(hitPos.x + randomX, hitPos.y + rayMoveUpDistance, hitPos.z + randomZ);

                                    RaycastHit hitGround;
                                    if (Physics.Raycast(readySpawnPoints, Vector3.down, out hitGround, rayMoveUpDistance, 1 << LayerMask.NameToLayer("Ground")))
                                    {
                                        if (arImage == "Greengrass")
                                        {
                                            int GrassIndex = Random.Range(0, GrassGrass.Length);
                                            //hitPos = hitPos + Vector3.up * GrassPlants[PlantsIndex].transform.localScale.y / 2;
                                            Instantiate(GrassGrass[GrassIndex], hitGround.point, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
                                            Grass = Grass + 1;
                                            GrassScore = GrassScore + 1;
                                            if (Grass % 50 == 0)
                                            {
                                                InsBee(hitGround.point);
                                                //btnMouse.MouseOr();
                                            }
                                        }
                                        else
                                        {
                                            StartCoroutine(ExecuteFadeOutAfterDelay());
                                            audioSource.PlayOneShot(Sound);
                                        }
                                    }
                                }

                                //if (i == 0)
                                //{
                                //    //���������
                                //    float randomX = Random.Range(-BrushSize / 2, BrushSize / 2);
                                //    float randomZ = Random.Range(-BrushSize / 2, BrushSize / 2);

                                //    //����������ƶ�100m�����´�������
                                //    Vector3 readySpawnPoints = new Vector3(hitPos.x + randomX, hitPos.y + rayMoveUpDistance, hitPos.z + randomZ);

                                //    RaycastHit hitGround;
                                //    if (Physics.Raycast(readySpawnPoints, Vector3.down, out hitGround, rayMoveUpDistance, 1 << LayerMask.NameToLayer("Ground")))
                                //    {

                                //        int SnowIndex = Random.Range(0, SnowGrass.Length);
                                //        //hitPos = hitPos + Vector3.up * GrassPlants[PlantsIndex].transform.localScale.y / 2;
                                //        Instantiate(SnowGrass[SnowIndex], hitGround.point, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
                                //        Grass = Grass + 1;
                                //        GrassScore = GrassScore + 1;
                                //        if (Grass % 50 == 0)
                                //        {
                                //            InsBee(hitGround.point);
                                //        }
                                //    }
                                //}

                                if (i == 5)
                                {
                                    //���������
                                    float randomX = Random.Range(-BrushSize / 2, BrushSize / 2);
                                    float randomZ = Random.Range(-BrushSize / 2, BrushSize / 2);

                                    //����������ƶ�100m�����´�������
                                    Vector3 readySpawnPoints = new Vector3(hitPos.x + randomX, hitPos.y + rayMoveUpDistance, hitPos.z + randomZ);

                                    RaycastHit hitGround;
                                    if (Physics.Raycast(readySpawnPoints, Vector3.down, out hitGround, rayMoveUpDistance, 1 << LayerMask.NameToLayer("Ground")))
                                    {
                                        if (arImage == "Redgrass")
                                        {
                                            int RedIndex = Random.Range(0, RedGrass.Length);
                                            //hitPos = hitPos + Vector3.up * GrassPlants[PlantsIndex].transform.localScale.y / 2;
                                            Instantiate(RedGrass[RedIndex], hitGround.point, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
                                            Grass = Grass + 1;
                                            GrassScore = GrassScore + 1;
                                            if (Grass % 50 == 0)
                                            {
                                                InsBee(hitGround.point);
                                                //btnMouse.MouseOr();
                                            }
                                        }
                                        else
                                        {
                                            StartCoroutine(ExecuteFadeOutAfterDelay());
                                            audioSource.PlayOneShot(Sound);
                                        }
                                    }
                                }
                                if (i == 0|| i == 1 || i == 2 || i == 4 || i == 6 || i == 7 || i == 8 )
                                {
                                    StartCoroutine(ExecuteFadeOutAfterDelay());
                                    audioSource.PlayOneShot(Sound);
                                }
                            }
                        }
                    }
                }
            }
        }

        void InsBee(Vector3 hitp)
        {
            GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
            if (Random.value < 0.05f * Grass && animals.Length == 0)
            {
                GameObject BeeInstance = Instantiate(Bee, hitp, Quaternion.identity);
                BeeController beeController = BeeInstance.GetComponent<BeeController>();
                TreePos = hitp;
                beeController.SetCenterPoint(TreePos);
                treeSpawn.IncreasePlantNum(5);
                GrassScore = GrassScore + 50;
                // ����ͼƬ�� Alpha ֵΪ 255
                Image image5 = GameObject.Find("Image (1)").GetComponent<Image>();
                Color color = image5.color;
                color.a = 1f; // ���� Alpha ֵΪ 1��255 / 255��
                image5.color = color;

                savedColor5 = image5.color;
                PlayerPrefs.SetString("ImageColor5", ColorUtility.ToHtmlStringRGBA(savedColor5));
            }
        }
        IEnumerator ExecuteFadeOutAfterDelay()
        {
            // ִ��FadeIn
            uishow2.UI_FadeIn_Event();
            // �ȴ�2��
            yield return new WaitForSeconds(2f);
            // ִ��FadeOut
            uishow2.UI_FadeOut_Event();
        }

        
    }
    void SetBeeIcon(Color color)
    {
        Image image5 = GameObject.Find("Image (1)").GetComponent<Image>();
        image5.color = color;
    }
}
