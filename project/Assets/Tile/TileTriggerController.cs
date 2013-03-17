using UnityEngine;
using System.Collections;

public class TileTriggerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerExit(Collider other) {
		Debug.Log("EXIT " + other.name);
		
		if(other.gameObject.GetComponent("PlayerController") != null) {
			((PlayerController)other.gameObject.GetComponent(typeof(PlayerController))).OnExitTile();
		}
	}
	
}
