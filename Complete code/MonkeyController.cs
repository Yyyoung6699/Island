using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    public Vector3 centerPoint;  // 出生位置的中心点
    AudioSource audioSS;
    public AudioClip MonkeyAudio;

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
        transform.rotation = Quaternion.Euler(0f, 120f, 0f);
        audioSS = GetComponent<AudioSource>();//获得声音
        audioSS.clip = MonkeyAudio;
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
