using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	// Player Handling
	public float gravity = 20;
	public float walkSpeed = 8;
	public float runSpeed = 12;
	public float acceleration = 30;
	public float jumpHeight = 12;
	public float slideDeceleration = 10;
	
	// System
	private float animationSpeed;
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	// States
	private bool jumping;
	private bool sliding;


	// Components
	private PlayerPhysics playerPhysics;
	

	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();

	}
	
	void Update () {
		// Reset acceleration upon collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			
			// Jump logic
			if (jumping) {
				jumping = false;

			}
			
			// Slide logic
			if (sliding) {
				if (Mathf.Abs(currentSpeed) < .25f) {
					sliding = false;
							playerPhysics.ResetCollider();
				}
			}
			
			
			// Jump Input
			if (Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;
				jumping = true;

			}
			
			// Slide Input
			if (Input.GetButtonDown("Slide")) {
				sliding = true;

				targetSpeed = 0;
				
				playerPhysics.SetCollider(new Vector3(10.3f,1.5f,3), new Vector3(.35f,.75f,0));
			}
		}
		
		// Set animator parameters
		
		// Input
		if (!sliding) {
			float speed = (Input.GetButton("Run"))?runSpeed:walkSpeed;
			targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
			
			// Face Direction
			float moveDir = Input.GetAxisRaw("Horizontal");
			if (moveDir !=0) {
				transform.eulerAngles = (moveDir>0)?Vector3.up * 180:Vector3.zero;
			}
		}
		else {
			currentSpeed = IncrementTowards(currentSpeed, targetSpeed,slideDeceleration);
		}
		
		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);

	}
	
	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
}
