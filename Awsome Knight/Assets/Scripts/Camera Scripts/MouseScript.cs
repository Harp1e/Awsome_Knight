using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour 
{
    public Texture2D cursorTexture;
    public GameObject mousePoint;

    CursorMode mode = CursorMode.ForceSoftware;
    Vector2 hotSpot = Vector2.zero;
    GameObject instantiatedMouse;
	
	void Update () 
	{
        Cursor.SetCursor (cursorTexture, hotSpot, mode);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    Vector3 temp = hit.point;
                    temp.y = 0.25f;
                    if (instantiatedMouse != null)
                    {
                        Destroy (instantiatedMouse);                      
                    }
                    instantiatedMouse = Instantiate (mousePoint) as GameObject;
                    instantiatedMouse.transform.position = temp;
                }
            }
        }
	}
}
