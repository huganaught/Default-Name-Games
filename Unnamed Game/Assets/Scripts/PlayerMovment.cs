using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

	public float speed = 6f;
	public float maxSpeed = 3f;
	//public float jumpPower = 5f;
	//public bool grounded;
	//public float fuel = 100f;
	//public bool jumpRelease = true;
	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> (); // The objects
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("Grounded",grounded);

		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));

		// Flips sprite depending on last direction of input
		if (rb2d.velocity.x <= -0.1) { 
			transform.localScale = new Vector3 (-1, 1, 1);
		} 
		if (rb2d.velocity.x >= 0.1) { 
			transform.localScale = new Vector3 (1, 1, 1);
		} 
		//fuel = fuel + (Time.deltaTime); // Fuel goes up with time
	}

	public void InputManager (float h){
		rb2d.AddForce ((Vector2.right * speed) * h); //apply force
		//limit speed
		if (rb2d.velocity.x > maxSpeed) { 
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		} else if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
	// below is for mobile input using invisible buttons - - - NEEDS BETTER METHOD USING 'TOUCHES'
	public bool rightBut;

	public void rightIn (){
		rightBut = true;
	}

	public void rightOut (){
		rightBut = false;
	}

	public bool leftBut;

	public void leftIn(){
		leftBut = true;
	}

	public void leftOut(){
		leftBut = false;
	}

	public void JumpManager (float v){
		if (grounded == true ) {
			jumpRelease = true;
		}
		if (v > 0 && grounded == true && jumpRelease == true) { //&& fuel > 1
			//fuel = fuel - 1;
			rb2d.AddForce (Vector2.up * jumpPower);
			jumpRelease = false;
		}
	}


	// Update is called once per physics tick
	void FixedUpdate () {
		 // GetAxis("Horizontal") from input settings Input named "Horizontal" | acceleration.x
		float h = Input.GetAxis ("Horizontal");
		if (rightBut == true) {
			h = 1;
		}

		if (leftBut == true) {
			h = -1;
		}

		InputManager (h);

		JumpManager (Input.GetAxis("Vertical"));
	
	}
}


// Jump disabled problems with mobile input and jump release
/*
if (Input.GetButtonDown ("Vertical") == true && grounded == true){
	jumpRelease = true;
} 



float v = Input.GetAxis ("Vertical");
if (v > 0 && grounded == true && jumpRelease == true) { //&& stamina > 5
	//stamina = stamina - 5;
	rb2d.AddForce (Vector2.up * jumpPower);
	jumpRelease = false;
}
*/