using UnityEngine;
using System.Collections;

using System;
using SmartFoxClientAPI;
using SmartFoxClientAPI.Data;

public class RemotePlayercontr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		Debug.Log("HURT");
		//If the collision belongs to the player's weapons
		if(collider.gameObject.GetComponent("WeaponController") != null) {
			if(((WeaponController)collider.gameObject.GetComponent(typeof(WeaponController))).IsAttacking()) {
				int damage = ((WeaponController)collider.gameObject.GetComponent(typeof(WeaponController))).GetDamage();
				SendDamage(damage);
			}
		}
	}
	
	void SendDamage(int damage){
		SmartFoxClient client = NetworkController.GetClient();
		SFSObject data = new SFSObject();
		data.Put("_cmd", "d");  //We put _cmd = "d" to identify the message as a damage message
		data.Put("amount", damage); //how much damage was dealt
		client.SendObject(data);
	}
}
