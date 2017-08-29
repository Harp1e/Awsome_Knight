using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
    public float health = 100f;

    bool isShielded;

    Animator anim;
    Image health_Img;

    void Awake ()
    {
        anim = GetComponent<Animator> ();
        health_Img = GameObject.Find ("Health Icon").GetComponent<Image> ();
        Time.timeScale = 1f;
    }

    public bool Shielded
    {
        get { return isShielded; }
        set { isShielded = value; }
    }
	
	public void TakeDamage (float amount) 
	{
        if (!isShielded)
        {
            health -= amount;
            health_Img.fillAmount = health / 100f;

            if (health <= 0f)
            {
                anim.SetBool ("Death", true);
                if (!anim.IsInTransition (0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") &&
                    anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.5f)
                {
                    StartCoroutine (KillPlayer ());
                }
            }
        }
    }

    public void HealPlayer (float healAmount)
    {
        health += healAmount;
        if (health > 100f)
        {
            health = 100f;
        }
        health_Img.fillAmount = health / 100f;
    }

    IEnumerator KillPlayer ()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime (2f);
        SceneManager.LoadScene (0);
    }
}
