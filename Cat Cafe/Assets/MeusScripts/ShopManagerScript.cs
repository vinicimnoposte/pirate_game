using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public float coins;
    
    public TextMeshProUGUI CoinsTXT;
    public GameObject player;
    public GameObject[] hearts;
   // public GameObject Heart5, Heart4, Heart3, Heart2, Heart1;
    
    
    public float timerWarning;
    public float intervalo;
    public GameObject heartBuy;
    public GameObject m4buy;

    public GameObject bacamarte;
    
    public GameObject heart5;
    

    void Start()
    {
        CoinsTXT.text = coins.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
       

        //Price
        shopItems[2, 1] = 1;
        shopItems[2, 2] = 2;
        shopItems[2, 3] = 3;
       

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;

        hearts = player.GetComponent<CharController>().hearts;

        bacamarte.SetActive(false);
        
    }
     void Update()
     {
        //CoinsTXT.text = coins.ToString();
        player.GetComponent<CoinPick>().textCoins.text = coins.ToString();
        if(coins <= 0)
        {
            m4buy.GetComponent<Button>().interactable = false;
            heartBuy.GetComponent<Button>().interactable = false;
        }
        else
        {

            m4buy.GetComponent<Button>().interactable = true;
            if (player.GetComponent<CharController>().life < 5)           
                heartBuy.GetComponent<Button>().interactable = true;         
            else
                heartBuy.GetComponent<Button>().interactable = false;
        }
        if (bacamarte.activeInHierarchy)
            m4buy.GetComponent<Button>().interactable = false;
        
     }


    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

        }
        if(shopItems[3,2] == 1)
        {
            bacamarte.SetActive(true);
            m4buy.GetComponent<Button>().interactable = false;

        }
        
        
    }
    public void Heal()
    {
       // if (Heart2.activeInHierarchy == false && Heart1.activeInHierarchy == true)
       // {
       //     Heart2.SetActive(true);
       //     player.GetComponent<HeartSystem>().life++;
       //     shopItems[3, 1]--;
       // }
       // if (Heart3.activeInHierarchy == false && Heart2.activeInHierarchy == true)
       // {
       //     Heart3.SetActive(true);
       //     player.GetComponent<HeartSystem>().life++;
       //     shopItems[3, 1]--;
       // }
       // if (Heart4.activeInHierarchy == false && Heart3.activeInHierarchy == true)
       // {
       //     Heart4.SetActive(true);
       //     player.GetComponent<HeartSystem>().life++;
       //     shopItems[3, 1]--;
       // }
       // if (Heart5.activeInHierarchy == false && Heart4.activeInHierarchy == true)
       // {
       //     Heart5.SetActive(true);
       //     player.GetComponent<HeartSystem>().life++;
       //     shopItems[3, 1]--;
       // }
        for (int i = 0; i <= hearts.Length; i++)
        {
            if (hearts[i].activeInHierarchy == false)
            {
                player.GetComponent<CharController>().life++;
                hearts[i].SetActive(true);
                shopItems[3, 1]--;
                break;
            }
            //if(hearts[4].activeInHierarchy)
            //{
            //    heartBuy.GetComponent<Button>().interactable = false;
            //    
            //}

        }
    }
}
