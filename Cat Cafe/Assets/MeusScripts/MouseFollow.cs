using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Ray cameraRay;
    RaycastHit cameraRayHit;


    // Update is called once per frame
    void Update()
    {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out cameraRayHit))

        {
            if (cameraRayHit.transform.tag == "Ground")
            {

                Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);

                transform.LookAt(targetPosition);
            }

        }
    }
}
