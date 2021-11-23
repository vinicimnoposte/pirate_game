using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject player;
    public int life;
    private bool dead;

    private void Start()
    {
        life = hearts.Length;
    }


    void Update()
    {
        if (dead == true)
        {
            Debug.Log("Morri :(");
            Application.Quit();
            Debug.Log("Quit!");
        }
    }
    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Debug.Log("tomei dano");
            hearts[life].SetActive(false);
            Debug.Log("desativei");
           // Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                dead = true;
            }
        }
    }
}
