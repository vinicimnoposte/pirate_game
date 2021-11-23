using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    
    public GameObject player;
    public GameObject gustavo;
    
    public float gaxisX;
    public float gaxisY;
    public float gaxisZ;
 


    void Update()
    {
      
        gustavo.transform.position = player.transform.position + new Vector3(gaxisX, gaxisY , gaxisZ);
        
    }
}
