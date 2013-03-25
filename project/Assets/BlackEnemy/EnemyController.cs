using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public Transform target;
	GameObject player;
	float maxRange;	
	float minRange;
	float attackRange;
	float enemySpeed;
	int enemyHealth;
	int attackPower;
	double lastAttack;
	double attackDelay = 1.0;
	
	// Use this for initialization
	void Start () {
		
		this.renderer.material.color = Color.red;
		
		maxRange = 4.0F;
		minRange = 0.5F;
		attackRange = 2.0F;
		attackPower = 4;
		lastAttack = 0.0;
		enemySpeed = 0.02F;
		enemyHealth = 20;
		
		player = GameObject.FindGameObjectWithTag("Player");
		
		if(player!= null) {
			target = player.transform;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(target != null) {
			if((Vector3.Distance(transform.position,target.position)<maxRange) && (Vector3.Distance(transform.position,target.position)>minRange)){
				transform.LookAt(target);
				transform.Translate(Vector3.forward * enemySpeed);
			}
			
			//Attack the player
			if(Vector3.Distance(transform.position,target.position) < attackRange && (Time.time>lastAttack)) {
				lastAttack = Time.time + attackDelay;
				((PlayerController)player.GetComponent(typeof(PlayerController))).OnDamage(attackPower);
			}
		}
		

	}
	
	void OnTriggerEnter(Collider collider) {
		Debug.Log("HURT");
		//If the collision belongs to the player's weapons
		if(collider.gameObject.GetComponent("WeaponController") != null) {
			if(((WeaponController)collider.gameObject.GetComponent(typeof(WeaponController))).IsAttacking()) {
				int damage = ((WeaponController)collider.gameObject.GetComponent(typeof(WeaponController))).GetDamage();
				OnDamage(damage);
			}
		}
	}
	
	public void OnDamage(int damage) {
		enemyHealth = enemyHealth - damage;
		
		if(enemyHealth <= 0) {
			Destroy (this.gameObject);	
		}
		
	}
}
