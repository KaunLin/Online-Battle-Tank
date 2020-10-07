using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MoveTank : NetworkBehaviour{
	public GameObject missilePrefab;
	public Transform endOfCanon;
	public override void OnStartLocalPlayer(){
		GetComponent<MeshRenderer> ().material.color = Color.green;
		GameObject.Find ("Main Camera").transform.parent = gameObject.transform;
		GameObject.Find ("Main Camera").transform.localPosition = new Vector3 (0.0f, transform.position.y + 10, 0);
	}
	[Command]
	void CmdFire(){
		var missile = (GameObject)Instantiate (missilePrefab, endOfCanon.position, endOfCanon.rotation);
		missile.GetComponent<Rigidbody> ().velocity = missile.transform.forward * 6;
		Destroy (missile, 2.0f);
		NetworkServer.Spawn (missile);
	}
	void Update(){
		if (!isLocalPlayer) {
			return;
		}
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;
		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);
		if (Input.GetKeyDown (KeyCode.Space)) {
			CmdFire ();
		}
	}

}
