using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBackBan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BanBtn()
    {
        GetComponent<Button>().interactable = false;
    }
    public void RunBtn()
    {
        GetComponent<Button>().interactable = true;
    }
}
