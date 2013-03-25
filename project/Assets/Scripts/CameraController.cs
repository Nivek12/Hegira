using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Make the camera follow the player
		if(player != null) {
			transform.position = new Vector3(player.position.x, player.position.y + 5, player.position.z);
		}
	}
}
