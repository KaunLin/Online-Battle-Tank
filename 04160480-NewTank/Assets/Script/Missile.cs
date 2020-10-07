using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Missile : NetworkBehaviour {
	public GameObject explosionPrefab;
	void OnCollisionEnter(Collision collision){
		Tank tank = collision.collider.gameObject.GetComponent <Tank> ();
		if (tank != null) {
			tank.GetHit ();
			CreatExplosion ();
			Destroy (gameObject);
		}
	}
	void CreatExplosion (){
		var explosion = (GameObject)Instantiate (explosionPrefab, transform.position, transform.rotation);
		Destroy (explosion, 2.0f);
	}
}
