using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class BulletMovement : MonoBehaviour {

	private int damage = 10;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * 10;
		transform.position = transform.position + transform.forward * 1.5f;
		Destroy (this.gameObject, 2.0f);
	}

	// Update is called once per frame
	void OnCollisionEnter (Collision c) {
		PlayerHealth health = c.collider.GetComponent<PlayerHealth> ();
		if (health != null) {
			health.TakeDamage (damage);
			Destroy (this.gameObject);
		}

	}
}