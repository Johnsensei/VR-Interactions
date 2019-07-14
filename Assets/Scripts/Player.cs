using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float playerSpeed;
	public Vector3 castlePosition;
	public GameObject playerObject;
	public bool enteredCastle;

	public Vector3 startPosition;
	private Vector3 targetPosition;

	private float distanceToMove = 22f;

	// Use this for initialization
	void Start () {

		targetPosition = startPosition;

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (hit.transform.GetComponent<DoorButton> () != null) {
				hit.transform.GetComponent<DoorButton> ().OnLook ();
				MoveToCastle ();
			}

			playerObject.transform.position = Vector3.Lerp (playerObject.transform.position, startPosition, playerSpeed * Time.deltaTime);
		}

		playerObject.transform.position = Vector3.Lerp (playerObject.transform.position, targetPosition, Time.deltaTime * playerSpeed);
	
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")){
			RaycastHit enemyHit;

			if (Physics.Raycast (transform.position, transform.forward, out enemyHit)) {
				if (hit.transform.GetComponent<Enemy> () != null) {
					Destroy (hit.transform.gameObject);
				}
			}
		}
	
	}

	private void MoveToCastle(){
		targetPosition = castlePosition;
		enteredCastle = true;
		Debug.Log ("I should be moving to the castle.");

	}
}
