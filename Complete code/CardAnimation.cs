using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public GameObject MushRoomCard;
    public GameObject RGrassCard;
    public GameObject GGrassCard;
    public GameObject SnowCard;
    public GameObject SandCard;
    public GameObject GreenCard;
    public GameObject RedCard;
    string arImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arImage = DefaultObserverEventHandler.ArImage;
        if (arImage != null)
        {
            switch (arImage)
            {
                case "Redtree":
                    RedCard.SetActive(true);
                    break;
                case "Greentree":
                    GreenCard.SetActive(true);
                    break;
                case "Sandtree":
                    SandCard.SetActive(true);
                    break;
                case "Snowtree":
                    SnowCard.SetActive(true);
                    break;
                case "Greengrass":
                    GGrassCard.SetActive(true);
                    break;
                case "Mushroom":
                    MushRoomCard.SetActive(true);
                    break;
                case "Redgrass":
                    RGrassCard.SetActive(true);
                    break;
            }
        }
    }
}
