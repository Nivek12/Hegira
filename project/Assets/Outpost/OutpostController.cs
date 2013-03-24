using UnityEngine;
using System.Collections;

public class OutpostController : MonoBehaviour {
	
	public GameObject HelpEmitter;
	public GameObject FriendEmitter;
	public GameObject TradeEmitter;
	
	double emitLength = 10;
	
	bool hasPlayer = false;
	
	// Use this for initialization
	void Start () {
		hasPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		
		//If a player is in the outpost, then show them the radio UI
		
		if(hasPlayer) {
			
			//Help signal
			if(GUI.Button(new Rect(800 , 300, 80, 30), "HELP")) {
				HelpEmitter.particleEmitter.Emit();
			}
			
			//Friend signal
			if(GUI.Button(new Rect(800 , 330, 80, 30), "FRIENDS")) {
				FriendEmitter.particleEmitter.Emit();
			}
			
			//Trade signal
			if(GUI.Button(new Rect(800 , 360, 80, 30), "TRADE")) {
				TradeEmitter.particleEmitter.Emit();
			}
			
		}
	}
	
	void OnTriggerEnter(Collider other) {
		
		//If the player is inside the outpost, then enable their inventory
		if(other.gameObject.GetComponent("InventoryGUI") != null) {
			((InventoryGUI)other.gameObject.GetComponent(typeof(InventoryGUI))).ShowInventory();
			hasPlayer = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		
		
		//If the player exits the outpost, then close their inventory
		if(other.gameObject.GetComponent("InventoryGUI") != null) {
			((InventoryGUI)other.gameObject.GetComponent(typeof(InventoryGUI))).CloseInventory();
			hasPlayer = false;
		}
	}
}
