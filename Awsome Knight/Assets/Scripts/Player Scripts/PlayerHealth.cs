using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    public float health = 100f;

    bool isShielded;

	public bool Shielded
    {
        get { return isShielded; }
        set { isShielded = value; }
    }
	
	void TakeDamage (float amount) 
	{
        if (!isShielded)
        {
            health -= amount;
            if (health <= 0f)
            {
                // player dies
            }
        }
    }
}
