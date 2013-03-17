using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Variables
    public float speed = 1.0F;
    public float jumpSpeed = 8.0F; 
    public float gravity = 20.0F;
	public bool showInventory = false; 
    private Vector3 moveDirection = Vector3.zero;
	
	public int numFood = 0;
	public string foodLabel = "FOOD: 0";
 
    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded) {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
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
    }
	
	public void onGetResource(int amount) {
		numFood += amount;
		foodLabel = "FOOD: " + numFood;
	}
	
	void OnGUI() {
	   GUI.Label(new Rect(10, 10, 150, 100), foodLabel);     
	}
	
	public void OnExitTile() {
		
		//Show the inventory
		showInventory = true; 
	}
}
