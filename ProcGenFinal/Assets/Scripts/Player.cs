﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float speed;
	
	// Update is called once per frame
	void Update () {
		
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * speed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * speed;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
		
	}
}
