using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
// Require empty collider set as isTrigger as child of object can be reused for collision detection
	private PlayerMovment player;

	void Start() {
		player = gameObject.GetComponentInParent<PlayerMovment>(); 
	}

	void OnTriggerEnter2D (Collider2D other) { // Built-in Unity function
		player.grounded = true;
	}

	void OnTriggerExit2D (Collider2D other){
		player.grounded = false;
	}

}
