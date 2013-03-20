using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Variables
    public float speed = 1.0F;
	public float rotateSpeed = 6.0F;
    public float jumpSpeed = 8.0F; 
    public float gravity = 20.0F;
	public bool showInventory = false; 
    private Vector3 moveDirection = Vector3.zero;
	
	public int numFood = 0;
	public int mDefense = 0;
	public int mHealth = 50;
	
	public string foodLabel = "FOOD: 0";
	public string healthLabel = "HEALTH: 50";
 
    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded) {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
 
        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
		
		if(Input.GetMouseButtonDown(0)){
    		//Attack
			renderer.material.color = Color.yellow;
		} else if(!Input.GetMouseButtonDown(0)) {
			renderer.material.color = Color.white;
		}
		
		//-----------------------------------------Make the player face the mouse-----------------------------
		// Generate a plane that intersects the transform's position with an upwards normal.
   		var playerPlane = new Plane(Vector3.up, transform.position);
 
    	// Generate a ray from the cursor position
   		 var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
 
	    // Determine the point where the cursor ray intersects the plane.
	    // This will be the point that the object must look towards to be looking at the mouse.
	    // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
	    //   then find the point along that ray that meets that distance.  This will be the point
	    //   to look at.
	    var hitdist = 0.0F;
	    // If the ray is parallel to the plane, Raycast will return false.
	    if (playerPlane.Raycast(ray, out hitdist)) {
	        // Get the point along the ray that hits the calculated distance.
	        var targetPoint = ray.GetPoint(hitdist);
	 
	        // Determine the target rotation.  This is the rotation if the transform looks at the target point.
	        var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
	 
	        // Smoothly rotate towards the target point.
	      	transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime); // WITH SPEED
	        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1); // WITHOUT SPEED!!!
	    }
    }
	
	public void SetDefense(int defense) {
		Debug.Log("ADDED ARMOR " + defense);
		mDefense = defense;
	}
	
	public void OnHeal(int healed) {
		
		if((mHealth + healed) > 100) {
			mHealth = 100;	
		} else {
			mHealth += healed;	
		}
		
		healthLabel = "HEALTH: " + mHealth;
	}
	
	public void OnDamage(int damage) {
		
		//Only hurt the player if the damage dealt is greater than their defense
		if(damage > mDefense) {
			mHealth = mHealth - (damage-mDefense);	
		}
		
		//TODO check if the player is dead
	}
	
	public void onGetResource(int amount) {
		numFood += amount;
		foodLabel = "FOOD: " + numFood;
	}
	
	void OnGUI() {
	   GUI.Label(new Rect(200, 10, 150, 100), healthLabel);     
	}
	
}
