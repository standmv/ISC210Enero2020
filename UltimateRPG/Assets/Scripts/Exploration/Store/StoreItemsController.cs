using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemsController : MonoBehaviour
{
    public int Price;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Jump"))
        {
            switch (gameObject.name)
            {
                case "GunType1":
                    BuyIfCoinsEnough(gameObject.GetComponent<StoreItemsController>().Price, other.gameObject.GetComponent<ExplorationPlayerController>(), gameObject.name);
                    break;
                case "GunType2":
                    BuyIfCoinsEnough(gameObject.GetComponent<StoreItemsController>().Price, other.gameObject.GetComponent<ExplorationPlayerController>(), gameObject.name);
                    break;
                case "GunType3":
                    BuyIfCoinsEnough(gameObject.GetComponent<StoreItemsController>().Price, other.gameObject.GetComponent<ExplorationPlayerController>(), gameObject.name);
                    break;
                case "MedicalKit":
                    BuyIfCoinsEnough(gameObject.GetComponent<StoreItemsController>().Price, other.gameObject.GetComponent<ExplorationPlayerController>(), gameObject.name);
                    break;
                case "Backpack":
                    BuyIfCoinsEnough(gameObject.GetComponent<StoreItemsController>().Price, other.gameObject.GetComponent<ExplorationPlayerController>(), gameObject.name);
                    break;
                case "Bullets":
                    BuyIfCoinsEnough(gameObject.GetComponent<StoreItemsController>().Price, other.gameObject.GetComponent<ExplorationPlayerController>(), gameObject.name);
                    break;
                default:
                    break;
            }
        }
    }

    void BuyIfCoinsEnough(int itemPrice, ExplorationPlayerController playerScript, string itemName)
    {
        if (playerScript.Coins > itemPrice)
        {
            playerScript.Coins -= itemPrice;
            playerScript.Stock[itemName] += 1;
        }
        else
            Debug.Log("No tiene dinero suficiente");
    }
}
