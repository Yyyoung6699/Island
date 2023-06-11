using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    public GameObject Target;

    
    private float x = 19.31f;
    private float y = -24.7f;
    private float z = 3.5f;

    public float disance;
    private Vector3 tem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraControl();
    }

    private void LateUpdate()
    {
        Quaternion quaternion = Quaternion.Euler(x, y, z);

        tem = new Vector3(-20, 45, -disance);
        Vector3 position = quaternion * tem + Target.transform.position;

        transform.rotation = quaternion;
        transform.position = position;
    }

    void cameraControl()
    {
        if (Input.GetMouseButton(2))
        {
            y += Input.GetAxis("Mouse X");
        }
        if (y < -90)
            y = -90;
        if (y > 10)
            y = 10;
    }

 

}
