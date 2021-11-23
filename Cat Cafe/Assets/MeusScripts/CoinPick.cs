using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPick : MonoBehaviour
{
    ShopManagerScript coins;
    public GameObject loja;
    public TextMeshProUGUI textCoins;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            loja.GetComponent<ShopManagerScript>().coins++;
            
                    
            Destroy(other.gameObject);       
        }
       
    }
}
