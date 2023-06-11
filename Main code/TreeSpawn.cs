using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    private UIshow2 uishow2;
    private Camera cam;
    public GameObject[] GrassPlants;
    public GameObject[] RedPlants;
    public GameObject[] SnowPlants;
    public GameObject[] SandPlants;
    public GameObject[] RockPlants;

    [SerializeField] Material mat;
    int triangleIdx;
    Mesh mesh;
    int subMeshesNr;
    int matI = -1;
    Renderer rend;
    MeshCollider meshCollider;
    Ray ray;

    public int Trees = 0;
    public int SnowTrees = 0;
    public int SandTrees = 0;
    public int RedTrees = 0;
    public int GreenTrees = 0;//��������������
    public GameObject Bird;//�Ѿ�����˰���BirdController�Ľű�

    public int plantNum = 5;//����ֲ������

    public BtnMouse btnMouse;
    int Mousezhuangtai;//���

    public AudioClip Sound; // ��Ч�ļ�
    public AudioClip Sound2;
    private AudioSource audioSource; // AudioSource���
                                     // Start is called before the first frame update
    string arImage;
    void Start()
    {
        btnMouse = FindObjectOfType<BtnMouse>();//���
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();//��Ч
        uishow2 = FindObjectOfType<UIshow2>();
    }

    // Update is called once per frame
    void Update()
    {
        Mousezhuangtai = btnMouse.MouseZhuangtai;//���״̬
        if ((Input.GetKeyDown("mouse 0")) && Mousezhuangtai == 1)
        {
                RayCast();
        }
        Trees = RedTrees + GreenTrees + SandTrees;

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

                                LandCondition(i, hitPos);
                            }
                        }
                    }
                }
            }
        }
    }

    void SpawnPlants(GameObject spawnPla, Vector3 hitPos)
    {
        audioSource.PlayOneShot(Sound);
        //int PlantsIndex = Random.Range(0, spawnPla.Length);
        hitPos = hitPos + Vector3.up * spawnPla.transform.localScale.y / 2;
        Instantiate(spawnPla, hitPos, Quaternion.identity);
    }

        

    void LandCondition(int i, Vector3 hitPos)
    {
        switch (i)
        {
            case 0:
                if (arImage == "Snowtree")
                {
                SpawnPlants(SnowPlants[0], hitPos);
                SnowTrees = SnowTrees + 1;
                plantNum = plantNum - 1;//����ֲ����������
                }
                else
                {
                    StartCoroutine(ExecuteFadeOutAfterDelay());
                    audioSource.PlayOneShot(Sound2);
                }
                break;
            case 1:
                print("shuizhiwu");
                break;
            case 2:
                if (arImage == "Mushroom")
                {
                    print("shandingkushu");
                    SpawnPlants(RockPlants[0], hitPos);
                    plantNum = plantNum - 1;//����ֲ����������
                }
                else
                {
                    StartCoroutine(ExecuteFadeOutAfterDelay());
                    audioSource.PlayOneShot(Sound2);
                }
                break;
            case 3:
                if (arImage == "Greentree")
                {
                    SpawnPlants(GrassPlants[2], hitPos);
                    GreenTrees = GreenTrees + 1;//��ɫ��������
                    plantNum = plantNum - 1;//����ֲ����������
                    Debug.Log("The number of GreenTrees is" + GreenTrees);
                }
                else
                {
                    StartCoroutine(ExecuteFadeOutAfterDelay());
                    audioSource.PlayOneShot(Sound2);
                }
                break;
            case 4:
                print("xuezhiwu");
             
                break;
            case 5:
                if (arImage == "Redtree")
                {
                    print("hongshu");
                    SpawnPlants(RedPlants[0], hitPos);
                    RedTrees = RedTrees + 1;
                    plantNum = plantNum - 1;//����ֲ����������
                }
                else
                {
                    StartCoroutine(ExecuteFadeOutAfterDelay());
                    audioSource.PlayOneShot(Sound2);
                }
                break;
            case 6:
                print("mogu");
                plantNum = plantNum - 1;//����ֲ����������
                break;
            case 7:
                print("shuizhiwu");
                break;
            case 8:
                if (arImage == "Sandtree")
                {
                    print("redai");
                    SpawnPlants(SandPlants[0], hitPos);
                    SandTrees = SandTrees + 1;
                    plantNum = plantNum - 1;//����ֲ����������
                }
                else
                {
                    StartCoroutine(ExecuteFadeOutAfterDelay());
                    audioSource.PlayOneShot(Sound2);
                }
                break;
        }
    }
    public void IncreasePlantNum(int value)
    {
        plantNum += value;
    }
    private IEnumerator ExecuteFadeOutAfterDelay()
    {
        // ִ��FadeIn
        uishow2.UI_FadeIn_Event();
        // �ȴ�2��
        yield return new WaitForSeconds(2f);
        // ִ��FadeOut
        uishow2.UI_FadeOut_Event();
    }
}
