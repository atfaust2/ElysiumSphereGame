
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour {

	public GameObject holder;
	public Camera playerCamera;

	public float maxRollSpeed;
	public float jumpHeight;

	private bool isGrounded = true;
	private Rigidbody player;

	void Start() {
		
		this.player = this.GetComponent<Rigidbody> ();
	}
		
	void Update () {
		
		player.transform.forward = (playerCamera.transform.forward - player.transform.position);
	}

	void FixedUpdate () {

		// Move player relative to PlayerCamera's view
		if (isGrounded) {
			
			if (Input.GetKey (KeyCode.W)) {

				var forward = playerCamera.transform.TransformDirection (Vector3.forward);
				player.AddForce (forward * maxRollSpeed);
			}
			if (Input.GetKey (KeyCode.S)) {

				var back = playerCamera.transform.TransformDirection (Vector3.back);
				player.AddForce (back * maxRollSpeed);
			}
			if (Input.GetKey (KeyCode.A)) {

				var left = playerCamera.transform.TransformDirection (Vector3.left);
				player.AddForce (left * maxRollSpeed);
			}
			if (Input.GetKey (KeyCode.D)) {

				var right = playerCamera.transform.TransformDirection (Vector3.right);
				player.AddForce (right * maxRollSpeed);
			}
			if (Input.GetKey (KeyCode.Space)) {
				player.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);

				isGrounded = false;
			}
		}


		// Check player speed
		if (player.velocity.magnitude > maxRollSpeed && isGrounded) {
			player.velocity = player.velocity.normalized * maxRollSpeed;
		}
	}

	public void SpawnPlayer(string type, Vector3 location) {

		Instantiate (Resources.Load (type), location, Quaternion.identity);
	}

	// Test for collsions on layers
	void OnCollisionEnter (Collision hit) {

		if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Walkable")) {
			isGrounded = true;
		}
	}

    
    void OnTriggerEnter(Collider other)
    {

    }

}