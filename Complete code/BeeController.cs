using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public Vector3 centerPoint;  // 出生位置的中心点
    public float radius = 10f;     // 环绕半径
    public float speed = 2f;       // 环绕速度
    public float aheadDistance = 2f; // 超前的距离
    private float angle;           // 当前角度

    AudioSource audioSS;
    public AudioClip BeeAudio;

    public GameObject buttonPre; // 按钮的 Prefab
    private GameObject buttonBa; // 按钮的父对象

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

        // 获取中心点的初始位置
        Vector3 centerPosition = centerPoint;
        transform.position = new Vector3(centerPosition.x, centerPosition.y + 15, centerPosition.z);

        audioSS = GetComponent<AudioSource>();//获得声音

        audioSS.clip = BeeAudio;
        audioSS.Play();//鸟叫声音

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
            // 在centerPosition生成按钮
            GameObject buttonObject = Instantiate(buttonPre, PPos, Quaternion.identity);
            buttonObject.transform.SetParent(buttonBa.transform);
        }
    }
    void Update()
    {
        SizeChange();

        // 计算下一帧的位置和超前点位置
        angle += speed * Time.deltaTime;
        float x = centerPoint.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.z + Mathf.Sin(angle) * radius;
        float y = centerPoint.y + (Mathf.Sin(1.5f * angle) * radius) / 3;
        Vector3 newPosition = new Vector3(x, y + 10, z);

        // 计算超前点的位置
        float aheadX = centerPoint.x + Mathf.Cos(angle + 0.1f) * (radius + aheadDistance);
        float aheadZ = centerPoint.z + Mathf.Sin(angle + 0.1f) * (radius + aheadDistance);
        Vector3 aheadPosition = new Vector3(aheadX, transform.position.y, aheadZ);

        // 更新Sparrow_Animations对象的位置和朝向
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
