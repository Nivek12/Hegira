using UnityEngine;
using System.Collections;

public class ChestplateController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		//If the player collided with the food, then call the appropriate method
		if(other.gameObject.GetComponent("PlayerController") != null) {
			((ItemController)gameObject.GetComponent(typeof(ItemController))).AddToInventory();
		}
		
		Destroy (this.gameObject);	
	}
}
