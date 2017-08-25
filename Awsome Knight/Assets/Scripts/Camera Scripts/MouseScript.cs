﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour 
{
    public Texture2D cursorTexture;
    //    public GameObject mousePoint;

    CursorMode mode = CursorMode.ForceSoftware;
    Vector2 hotSpot = Vector2.zero;
    

	void Start () 
	{
		
	}
	
	void Update () 
	{
        Cursor.SetCursor (cursorTexture, hotSpot, mode);
	}
}
