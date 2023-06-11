using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projector : MonoBehaviour
{
    public BtnMouse btnMouse;
    int Mousezhuangtai;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        btnMouse = FindObjectOfType<BtnMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        Mousezhuangtai = btnMouse.MouseZhuangtai;
        //从屏幕射出鼠标位置的射线
        if (Mousezhuangtai != 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))//, 1 << LayerMask.NameToLayer("Ground")
            {
                mousePos = hit.point;
                transform.position = new Vector3(mousePos.x, mousePos.y + 100f, mousePos.z);
                //transform.position = Camera.main.transform.position;
            }
        }
    }
}
