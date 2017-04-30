using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {



	private GameObject player;




	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update() {
		//		print("RHoriz " + Input.GetAxis("RHoriz"));
		//		print("RVert " + Input.GetAxis("RVert"));
	}


	// use lateupdate to move stuff after rendering step
	void LateUpdate() {
		transform.LookAt(player.transform);



	}



}
