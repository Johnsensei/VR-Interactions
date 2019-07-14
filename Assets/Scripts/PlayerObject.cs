using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour {

	public float playerSpeed;
	public Vector3 castlePosition;

	public Vector3 playerPosition;

	public static PlayerObject Instance;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {

		playerPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, playerPosition, Time.deltaTime * playerSpeed);

	}

	public void MoveToCastle(){
		playerPosition = castlePosition;
	}
}
