using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {
	private PlayerManager manager;
	public GameObject bullet;
	// Use this for initialization

	public float timer;
	void Start () {
		manager = GetComponent<PlayerManager> ();
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}
		if (Input.GetButton ("Fire1") && timer <= 0) {
			for (int i = 0; i < 360; i += 360 / manager.level) {
				CmdFire (i);
			}
			timer = 0.5f;
		}
		timer -= Time.deltaTime;
	}

	[Command]
	private void CmdFire (int i) {
		GameObject go = GameObject.Instantiate (bullet, transform.position, Quaternion.Euler (0, 180 - i, 0));
		NetworkServer.Spawn (go);
	}

}