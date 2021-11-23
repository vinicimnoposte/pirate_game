using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public GameObject loja;
   // public bool isShopOn = false;

    public float timer;

     void Start()
    {
        loja.SetActive(false);
    }
     void Update()
    {
        if (loja.activeInHierarchy == true)
            timer += Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            loja.SetActive(true);
            
           // isShopOn = true;
        }
        if(/*isShopOn == true  &&*/ loja.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E) && timer >=.01f)
        {
            loja.SetActive(false);
            
           // isShopOn = false;
            timer = 0;
        
        }
    }
   

}
