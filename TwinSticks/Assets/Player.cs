using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// can also use GetButton?
		Debug.Log("H: " + CrossPlatformInputManager.GetAxis("Horizontal"));
		Debug.Log("V: " + CrossPlatformInputManager.GetAxis("Vertical"));
	}
}
