using UnityEngine;
using System.Collections;

public class OutpostController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		//If the player is inside the outpost, then enable their inventory
		if(other.gameObject.GetComponent("InventoryGUI") != null) {
			((InventoryGUI)other.gameObject.GetComponent(typeof(InventoryGUI))).ShowInventory();
		}
	}
	
	void OnTriggerExit(Collider other) {
		//If the player exits the outpost, then close their inventory
		if(other.gameObject.GetComponent("InventoryGUI") != null) {
			((InventoryGUI)other.gameObject.GetComponent(typeof(InventoryGUI))).CloseInventory();
		}
	}
}
