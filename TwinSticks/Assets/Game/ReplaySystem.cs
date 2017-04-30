using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 1000;  // use const over variable
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];


	private GameManager gm;
	private Rigidbody rigidBody;


	void Start () {
//		MyKeyFrame testKey = new MyKeyFrame(1.0f, Vector3.up, Quaternion.identity); // not used
		rigidBody = GetComponent<Rigidbody>();
		gm = FindObjectOfType<GameManager>();

	}



	void Update () {
		if (!gm.gamePaused) {
			if (gm.recording) { // bool in gm script true
				Record();
			} else {
				PlayBack();
			}
		}
	}





	private void Record() {
		Debug.Log("Is Recording");
		rigidBody.isKinematic = false;

		int frame = Time.frameCount % bufferFrames; // circular frame storage
//		print("Writing frame " + frame);
		float time = Time.time;

		// creating keyframes
		keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
	}





	void PlayBack() {
		rigidBody.isKinematic = true;

		int frame = Time.frameCount % bufferFrames;
//		print("Reading frame " + frame);

		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;
	}





	// three slashes to make summary
	/// <summary>
	/// A structure for storing time, rotation, and position.
	/// </summary>
	public struct MyKeyFrame { // can be class or struct
		public float frameTime;
		public Vector3 position;
		public Quaternion rotation;

		public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation) {
			frameTime = aTime;
			position = aPosition;
			rotation = aRotation;

		}
	}
}
