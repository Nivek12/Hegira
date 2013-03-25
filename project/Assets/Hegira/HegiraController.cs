using UnityEngine;
using System.Collections;

public class HegiraController : MonoBehaviour {
	
	bool showLaunch;
	
	// Use this for initialization
	void Start () {
		this.renderer.material.color = Color.red;
		showLaunch = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		//If the player collided with the trigger then show them the launch button
		if(other.gameObject.GetComponent("PlayerController") != null) {
			showLaunch = true;
		}
		
	}
	
	void OnTriggerExit(Collider other) {
		
		//If the player exits the then hide the launch button
		if(other.gameObject.GetComponent("PlayerController") != null) {
			showLaunch = false;
		}
		
	}
	
	void OnGUI() {
		
		if(showLaunch) {
			
			if(GUI.Button(new Rect(500 , 250, 500, 100), "SHIT SHIT GTFO" )) {
				
			}
			
		}
		
	}
	
	void Open()
	{
		this.renderer.material.color = Color.green;
	}
}
