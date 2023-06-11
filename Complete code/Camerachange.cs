using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerachange : MonoBehaviour
{
    public Camera mainCamera;
    public Camera mainCamera2;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        mainCamera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainCamera.enabled = !mainCamera.enabled;
            mainCamera2.enabled = !mainCamera2.enabled;
        }
    }
}
