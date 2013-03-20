using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		//If the player collided with the food, then call the appropriate method
		if(other.gameObject.GetComponent("PlayerController") != null) {
			((PlayerController)other.gameObject.GetComponent(typeof(PlayerController))).onGetResource(10);
			((ItemController)gameObject.GetComponent(typeof(ItemController))).AddToInventory();
			Destroy (this.gameObject);	
		}
		
		
	}
}
