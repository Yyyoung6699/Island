using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public Vector3 centerPoint;  // ����λ�õ����ĵ�
    public float radius = 10f;     // ���ư뾶
    public float speed = 2f;       // �����ٶ�
    public float aheadDistance = 2f; // ��ǰ�ľ���
    private float angle;           // ��ǰ�Ƕ�

    AudioSource audioSS;
    public AudioClip BeeAudio;

    public GameObject buttonPre; // ��ť�� Prefab
    private GameObject buttonBa; // ��ť�ĸ�����

    public float minSize = 1f;
    public float maxSize = 1f;
    public float growSpeed = 0.2f;
    private float randomSize;
    private bool sizeChange;
    private Vector3 currentScale;
    private Vector3 currentVelocity = Vector3.zero;

    Vector3 screenPos;
    private void Awake()
    {
        currentScale = transform.localScale;
    }
    public void SetCenterPoint(Vector3 TreePos)
    {
        centerPoint = TreePos;
    }

    void Start()
    {
        transform.localScale = Vector3.zero;
        sizeChange = true;
        randomSize = Random.Range(minSize, maxSize);

        // ��ȡ���ĵ�ĳ�ʼλ��
        Vector3 centerPosition = centerPoint;
        transform.position = new Vector3(centerPosition.x, centerPosition.y + 15, centerPosition.z);

        audioSS = GetComponent<AudioSource>();//�������

        audioSS.clip = BeeAudio;
        audioSS.Play();//�������

        screenPos = Camera.main.WorldToScreenPoint(centerPosition);
        Vector3 PPos = new Vector3(screenPos.x, screenPos.y + 140, screenPos.z);
        buttonBa = GameObject.Find("BtnCollection");
        if (buttonBa == null)
        {
            Debug.LogError("ButtonParent not found in the scene!");
        }
        else
        {
            print("ButtonParent was found!");
            // ��centerPosition���ɰ�ť
            GameObject buttonObject = Instantiate(buttonPre, PPos, Quaternion.identity);
            buttonObject.transform.SetParent(buttonBa.transform);
        }
    }
    void Update()
    {
        SizeChange();

        // ������һ֡��λ�úͳ�ǰ��λ��
        angle += speed * Time.deltaTime;
        float x = centerPoint.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.z + Mathf.Sin(angle) * radius;
        float y = centerPoint.y + (Mathf.Sin(1.5f * angle) * radius) / 3;
        Vector3 newPosition = new Vector3(x, y + 10, z);

        // ���㳬ǰ���λ��
        float aheadX = centerPoint.x + Mathf.Cos(angle + 0.1f) * (radius + aheadDistance);
        float aheadZ = centerPoint.z + Mathf.Sin(angle + 0.1f) * (radius + aheadDistance);
        Vector3 aheadPosition = new Vector3(aheadX, transform.position.y, aheadZ);

        // ����Sparrow_Animations�����λ�úͳ���
        transform.position = newPosition;
        transform.LookAt(aheadPosition);
    }
    private void SizeChange()
    {
        if (sizeChange == true)
        {
            this.transform.localScale = Vector3.SmoothDamp(transform.localScale, currentScale * randomSize, ref currentVelocity, growSpeed);
            if ((currentScale.x * randomSize - transform.localScale.x) <= 0.01f)
            {
                transform.localScale = new Vector3(currentScale.x * randomSize, currentScale.y * randomSize, currentScale.z * randomSize);
                sizeChange = false;
            }
        }
    }
}
