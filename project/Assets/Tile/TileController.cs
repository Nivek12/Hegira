using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {
	
	public int tileID;
	public GameObject food;
	
	// Use this for initialization
	void Start () {
		
		int numResources = Random.Range(3, 15);
		
		for( int i = 0; i < numResources; i++) {
			
			Vector3 resourcePos = new Vector3(transform.position.x + Random.Range(-3,3), transform.position.y, transform.position.z + Random.Range(-3,3));
			
			Instantiate(food, resourcePos, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
