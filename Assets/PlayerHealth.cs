using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerHealth : NetworkBehaviour {

	int initialHealth = 50;
	[SyncVar (hook = "UpdateHud")]
	int curHealth;
	public Slider healthSlider;

	void Start () {
		curHealth = initialHealth;
		UpdateHud (curHealth);
	}

	public void TakeDamage (int value) {
		if (!isServer) {
			return;
		}
		this.curHealth -= value;
		UpdateHud (curHealth);
		if (this.curHealth <= 0) {
			print ("died");
			RpcRespawn ();
		}
	}

	private void UpdateHud (int health) {
		healthSlider.value = (float) health / (float) initialHealth;
	}

	[ClientRpc]
	void RpcRespawn () {
		if (isLocalPlayer) {
			transform.position = Vector3.zero;
			Start ();
		}
	}
}