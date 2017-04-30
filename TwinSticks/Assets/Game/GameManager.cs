using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;
	public bool gamePaused = false;


	private float initialFixedDelta;


	void Start() {
		initialFixedDelta = Time.fixedDeltaTime;
//		PlayerPrefsManagerScript.UnlockLevel(2);
//		print(PlayerPrefsManagerScript.IsLevelUnlocked(1));
//		print(PlayerPrefsManagerScript.IsLevelUnlocked(2));
	}


	void Update () {
		if (!gamePaused) {
			if (CrossPlatformInputManager.GetButton("Fire1")) {
				recording = false;
			} else {
				recording = true;
			}
		}


		if (CrossPlatformInputManager.GetButtonDown("Pause") && gamePaused) {
			UnPauseGame();
		} else if (CrossPlatformInputManager.GetButtonDown("Pause") && !gamePaused) {
			PauseGame();
		}

		// UNTESTED hopes this will unpause the game if it starts paused from earlier save game state?
		if (gamePaused == false) {
			UnPauseGame();
		}
	}





	void PauseGame() {
		gamePaused = true;
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
		Debug.Log("Game Paused");
	}
	void UnPauseGame() {
		gamePaused = false;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = initialFixedDelta;
	}
// system paused on game startup
	private void OnApplicationPause(bool pause) {
		gamePaused = pause;
	}

}
