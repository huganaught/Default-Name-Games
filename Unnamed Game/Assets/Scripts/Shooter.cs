using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

// From old game: shoots a raycast to the cursor when clicked. (can be used to set the agnle?)

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;
	public AudioClip shootSound;
	float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No FirePoint?");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) { // Unity project buttons
				Shoot();
			}
		}
		else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}
	// Point and click fires a ray until hits something on whatToHit layer
	void Shoot () {
		GetComponent<AudioSource>().PlayOneShot(shoot);
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
		Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("Hit " + hit.collider.name + " and did " + Damage + " damage.");
		}
	}
}
