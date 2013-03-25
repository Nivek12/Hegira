using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {
	
	public int tileID;
	public GameObject food;
	public GameObject enemy;
	
	// Use this for initialization
	void Start () {
		
		int numResources = Random.Range(3, 15);
		
		for( int i = 0; i < numResources; i++) {
			
			Vector3 resourcePos = new Vector3(transform.position.x + Random.Range(-8,8), transform.position.y, transform.position.z + Random.Range(-8,8));
			
			Instantiate(food, resourcePos, transform.rotation);
		}
		
		int numEnemies = Random.Range (2, 3);
		for (int i = 0; i < numEnemies; i++)
		{
			Vector3 resourcePos = new Vector3(transform.position.x + Random.Range(-8,8), transform.position.y, transform.position.z + Random.Range(-8,8));
			
			Instantiate(enemy, resourcePos, transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
