using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BtnBan : MonoBehaviour
{
    public Text text;
    private TreeSpawn treeSpawn;
    int plantnum;
    string arImage;
    // Start is called before the first frame update
    void Start()
    {
        treeSpawn = FindObjectOfType<TreeSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        arImage = DefaultObserverEventHandler.ArImage;
        plantnum = treeSpawn.plantNum;
     
            if (arImage == "Greentree" || arImage == "Redtree" || arImage == "Sandtree" || arImage == "Snowtree" || arImage == "Mushroom")        
            {
            RunBtn();       
            }
            else
            {
            BanBtn();
            }
        text.text = plantnum.ToString();
    }
    
    void BanBtn()
    {
        GetComponent<Button>().interactable = false;
    }
    void RunBtn()
    {
        GetComponent<Button>().interactable = true;
    }
}
