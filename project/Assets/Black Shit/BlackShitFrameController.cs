using UnityEngine;
using System.Collections;

public class BlackShitFrameController : MonoBehaviour {
	
	public float initialSize = 100; // initial size of the black shit frame
	public float moveRate = 5; // how fast the black shit shrinks into the center, depending on how we implement this, the move rate could be replaced with a scripted coroutine
	public float numShit = 12; // the number of black shit objects created
	public float timeBetweenTurns = 10; // time between each turn, from when the frame stops and starts
	
	private float timer;
	private bool isMoving;
	
	public GameObject BlackShit;
	private GameObject[] BlackShitList;
	
	void Start () //initializes the black shit and the size of the frame collider
	{
		isMoving = true;
		timer = timeBetweenTurns;
		
		(collider as SphereCollider).radius = initialSize;
		float theta = 0;
		for (int i = 0; i < numShit; i++)
		{
			Instantiate (BlackShit, this.transform.position + new Vector3(Mathf.Cos (theta), 0, Mathf.Sin (theta)) * (collider as SphereCollider).radius, transform.rotation); // unit circle calculation
			theta += (360/numShit);
		}
		BlackShitList = GameObject.FindGameObjectsWithTag("BlackShit");
	}
	

	void Update () 
	{
		if (timer > 0)
			timer -= 1 * Time.deltaTime;
		if (timer <= 0)
		{
			moveRate += 0.1f; // increment difficulty of game (i.e speed of BS movement, time between turns.)
			timeBetweenTurns--;
			
			for (int i = 0; i < BlackShitList.Length; i++) // increase the speed of all shit
			{
				BlackShitList[i].GetComponent<BlackShitController>().maxSpeed += 0.1f;
				BlackShitList[i].GetComponent<BlackShitController>().minSpeed += 0.1f;
				BlackShitList[i].GetComponent<BlackShitController>().acceleration += 0.01f;
			}
			
			timer = timeBetweenTurns;
			isMoving = isMoving == true ? false : true;
		}
		
		if ((collider as SphereCollider).radius > 0 && isMoving)
			(collider as SphereCollider).radius -= moveRate * Time.deltaTime;		
	}
}
