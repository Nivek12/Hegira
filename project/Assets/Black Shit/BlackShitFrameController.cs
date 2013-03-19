using UnityEngine;
using System.Collections;

public class BlackShitFrameController : MonoBehaviour {
	
	public float initialSize = 100; // initial size of the black shit frame
	public float moveRate = 5; // how fast the black shit shrinks into the center, depending on how we implement this, the move rate could be replaced with a scripted coroutine
	public GameObject BlackShit;
	public float numShit = 12; // the number of black shit objects created
	
	void Start () //initializes the black shit and the size of the frame collider
	{
		(collider as SphereCollider).radius = initialSize;
		float theta = 0;
		for (int i = 0; i < numShit; i++)
		{
			Instantiate (BlackShit, this.transform.position + new Vector3(Mathf.Cos (theta), 0, Mathf.Sin (theta)) * (collider as SphereCollider).radius, transform.rotation); // unit circle calculation
			theta += (360/numShit);
		}
	}
	

	void Update () 
	{
		if ((collider as SphereCollider).radius > 0)
			(collider as SphereCollider).radius -= moveRate * Time.deltaTime;
	}
}
