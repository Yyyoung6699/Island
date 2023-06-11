using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class BtnMouse : MonoBehaviour
{
    public AudioClip buttonSound; // 音效文件
    private AudioSource audioSource; // AudioSource组件

    public int MouseZhuangtai = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseTree()
    {
        MouseZhuangtai = 1;
        audioSource.PlayOneShot(buttonSound);
    }

    public void MouseGrass()
    {
        MouseZhuangtai = 2;
        audioSource.PlayOneShot(buttonSound);
    }

    public void MouseOr()
    {
        MouseZhuangtai = 0;
        audioSource.PlayOneShot(buttonSound);
    }

    public void BtnCamera()
    {
        audioSource.PlayOneShot(buttonSound);
        SceneManager.LoadScene(1);
    }
}
