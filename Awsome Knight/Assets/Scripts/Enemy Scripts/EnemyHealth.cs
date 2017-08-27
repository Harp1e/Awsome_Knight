using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
    public float health = 100f;

    Image health_Img;

    void Awake ()
    {
        if (tag == "Boss")
        {
            health_Img = GameObject.Find ("Health Foreground Boss").GetComponent<Image>();
        }
        else
        {
            health_Img = GameObject.Find ("Health Foreground").GetComponent<Image> ();
        }
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        health_Img.fillAmount = health / 100f;
        if (health <= 0)
        {

        }
    }
}
