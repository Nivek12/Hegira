using UnityEngine;
using System.Collections;

public class BarrierController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.renderer.material.color = Color.red;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Open ()
	{
		Debug.Log ("Opened");
		this.renderer.material.color = Color.green;
		this.collider.enabled = false;
	}
}
