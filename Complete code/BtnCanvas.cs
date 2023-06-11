using UnityEngine;
using UnityEngine.EventSystems;
using UIFrame;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnCanvas : MonoBehaviour, IPointerClickHandler
{
    public float growSpeed = 0.5f;

    private float randomSize;
    private bool sizeChange;
    private Vector3 currentScale;
    private Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    {
        currentScale = transform.localScale;
    }
    void Start()
    {
        transform.localScale = Vector3.zero;
        sizeChange = true;
    }
    private void Update()
    {
        SizeChange();
    }
    private void SizeChange()
    {
        if (sizeChange == true)
        {
            this.transform.localScale = Vector3.SmoothDamp(transform.localScale, currentScale, ref currentVelocity, growSpeed);
            if ((currentScale.x - transform.localScale.x) <= 0.01f)
            {
                transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z);
                sizeChange = false;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject animalCam = GameObject.Find("AnimalCam");
        Test2 test2Script = animalCam.GetComponent<Test2>();
        test2Script.CloseShere();
        // 在点击按钮后删除按钮
        Destroy(gameObject);
    }
}
