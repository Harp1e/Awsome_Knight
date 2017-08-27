using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFXDamage : MonoBehaviour 
{
    public LayerMask playerLayer;
    public float radius = 0.3f;
    public float damageCount = 10f;

    PlayerHealth playerHealth;
    bool collided;
	
	void Update () 
	{
        Collider[] hits = Physics.OverlapSphere (transform.position, radius, playerLayer);
        foreach (Collider c in hits)
        {
            playerHealth = c.gameObject.GetComponent<PlayerHealth> ();
            collided = true;
        }
        if (collided)
        {
            playerHealth.TakeDamage (damageCount);
            enabled = false;
        }
	}
}
