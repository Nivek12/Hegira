using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	
	public int attackPower;
	public bool isAttacking;
	
	// Use this for initialization
	void Start () {
		isAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0)){
    		//Attack
			animation.Play();
			isAttacking = true;
		} else if(!Input.GetMouseButtonDown(0)) {
			
		}
		
		if(!animation.isPlaying) {
			isAttacking =  false;
		}
	}
	
	public int GetDamage() {
		return attackPower;
	}
	
	public bool IsAttacking() {
		return isAttacking;	
	}
}
