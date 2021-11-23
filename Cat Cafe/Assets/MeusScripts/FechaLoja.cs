using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FechaLoja : MonoBehaviour
{
    public GameObject loja;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(loja.activeInHierarchy == true)
        {
            loja.SetActive(false);
        }
    }
}
