using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Tank : NetworkBehaviour {
	public int shieldDammage = 0;
	public void GetHit(){
		if(!isServer){
			return;
		}
		shieldDammage += 10;
		if(shieldDammage >= 100){
			shieldDammage = 0;
			RpcRespawn ();
		}
	}
	[ClientRpc]
	void RpcRespawn(){
		if (isLocalPlayer) {
			Debug.Log ("Dead respawning");
			transform.position = Vector3.zero;
		}
	}
}