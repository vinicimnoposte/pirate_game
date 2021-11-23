using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    public GameObject projectile;

    public int damage = 1;

    Vector3 forward;
    Vector3 right;

    public GameObject[] hearts;
    //public GameObject Heart5, Heart4, Heart3, Heart2, Heart1;
    public GameObject player;
    public int life;
    private bool dead;

    Ray cameraRay;
    RaycastHit cameraRayHit;
    Vector3 targetPosition;

    



    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        life = hearts.Length;
    }
    void Update()
    {
        if (Input.anyKey)
            Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerShoot();

        }

        if (dead == true)
        {
            //Debug.Log("Morri :(");
            Application.Quit();
            //Debug.Log("Quit!");
        }

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out cameraRayHit))

        {
            if (cameraRayHit.transform.tag == "Ground" || cameraRayHit.transform.tag == "Enemy")
            {

                targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
               
                transform.LookAt(targetPosition);
                
            }
        }
        // if(Heart5.activeInHierarchy == false && Heart4.activeInHierarchy == false && Heart3.activeInHierarchy == false && Heart2.activeInHierarchy == false && Heart1.activeInHierarchy == true)
        // {
        //     life = 1;
        // }
        // if(Heart5.activeInHierarchy == false && Heart4.activeInHierarchy == false && Heart3.activeInHierarchy == false && Heart2.activeInHierarchy == true && Heart1.activeInHierarchy == true)
        // {
        //     life = 2;
        // }
        // if(Heart5.activeInHierarchy == false && Heart4.activeInHierarchy == false && Heart3.activeInHierarchy == true && Heart2.activeInHierarchy == true && Heart1.activeInHierarchy == true)
        // {
        //     life = 3;
        // }
        // if(Heart5.activeInHierarchy == false && Heart4.activeInHierarchy == true && Heart3.activeInHierarchy == true && Heart2.activeInHierarchy == true && Heart1.activeInHierarchy == true)
        // {
        //     life = 4;
        // }
        // if(Heart5.activeInHierarchy == true && Heart4.activeInHierarchy == true && Heart3.activeInHierarchy == true && Heart2.activeInHierarchy == true && Heart1.activeInHierarchy == true)
        // {      
        //     life = 5;          
        // }
        //jp e gay 8===D
        Debug.Log(hearts.Length);

        
    }
    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    private void PlayerShoot()
    {
        GameObject rb = Instantiate(projectile, transform.position, Quaternion.identity);
            
        rb.transform.LookAt(targetPosition);
      
        rb.GetComponent<Rigidbody>().AddForce(rb.transform.forward * 32f, ForceMode.Impulse);


        
        
    }
     public void TakeDamage(int d)
     {
         if (life >= 1)
         {
            life -= d;
            Debug.Log(life);
            hearts[life].SetActive(false);
           // Destroy(hearts[life].gameObject);
             if (life < 1)
             {
                 dead = true;
             }
         }
     }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damage);
        }      
    }
    
}
