using UnityEngine;
using System.Collections;

public class BlackShitController : MonoBehaviour {
	
	public GameObject BlackShitFrame;
	private Vector3 destination; // final destination of all the shit
	public float moveSpeed = 6; // current move speed
	public float maxSpeed = 6; //max speed
	public float acceleration = 0.5f; // how fast the shit accelerates to max speed
	
	void Start () 
	{
		destination = BlackShitFrame.transform.position; // make sure to change the position of the PREFAB if you want this line to take effect
	}
	
	void Update () {
		transform.position += (destination - transform.position).normalized * moveSpeed * Time.deltaTime; // takes the direction of movement and multiplies by the move speed
		if (moveSpeed <= maxSpeed)
			moveSpeed += acceleration * Time.deltaTime;
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.name == "BlackShitFrame") // if collides with the shit frame, lowers the speed. could be set to 0 for the pseudo turn based part of the game
			moveSpeed = 4;
	}
}
