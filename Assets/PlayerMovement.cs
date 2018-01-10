using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	public float speed = 5f;
	private CharacterController characterController;

	[SyncVar	]
	private float hue;

	void Start () {
		characterController = GetComponent<CharacterController> ();
		GetComponent<Renderer> ().material.color = Color.HSVToRGB (hue, 1, 1);
	}
	public override void OnStartLocalPlayer () {
		hue = (float) new System.Random ().NextDouble ();
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}
		characterController.SimpleMove (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * speed);
	}
}