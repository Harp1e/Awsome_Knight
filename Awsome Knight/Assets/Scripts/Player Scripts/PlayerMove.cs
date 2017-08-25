using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Animator anim;
    CharacterController charController;
    CollisionFlags collisionFlags = CollisionFlags.None;

    float moveSpeed = 5f;
    bool canMove;
    bool finished_Movement = true;

    Vector3 target_Pos = Vector3.zero;
    Vector3 player_Move = Vector3.zero;

    float player_ToPointDistance;

    float gravity = 9.8f;
    float height;

	void Awake ()
    {
        anim = GetComponent<Animator> ();
        charController = GetComponent<CharacterController> ();
	}
	
	void Update ()
    {
        CalculateHeight ();
        CheckIfFinishedMovement ();

    }

    bool IsGrounded ()
    {
        return collisionFlags == CollisionFlags.CollidedBelow ? true : false;
    }

    void CalculateHeight ()
    {
        if (IsGrounded())
        {
            height = 0f;
        }
        else
        {
            height -= gravity * Time.deltaTime;
        }
    }

    void CheckIfFinishedMovement ()
    {
        if (!finished_Movement)
        {
            if (!anim.IsInTransition (0) && !anim.GetCurrentAnimatorStateInfo (0).IsName ("Stand") &&
                anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.8f)
            {
                finished_Movement = true;
            }
        }
        else
        {
            MoveThePlayer ();
            player_Move.y = height * Time.deltaTime;
            collisionFlags = charController.Move (player_Move);
        }
    }

    void MoveThePlayer ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    player_ToPointDistance = Vector3.Distance (transform.position, hit.point);
                    if (player_ToPointDistance >= 1.0f)
                    {
                        canMove = true;
                        target_Pos = hit.point;
                    }
                }
            }
        }

        if (canMove)
        {
            anim.SetFloat ("Walk", 1.0f);
            Vector3 target_Temp = new Vector3 (target_Pos.x, transform.position.y, target_Pos.z);
            transform.rotation = Quaternion.Slerp (transform.rotation,
                Quaternion.LookRotation (target_Temp - transform.position),
                15.0f * Time.deltaTime);
            player_Move = transform.forward * moveSpeed * Time.deltaTime;
            if (Vector3.Distance (transform.position, target_Pos) <= 0.5f)
            {
                canMove = false;
            }
        }
        else
        {
            player_Move.Set (0f, 0f, 0f);
            anim.SetFloat ("Walk", 0f);
        }
    }
}
