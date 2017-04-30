using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManagerScript : MonoBehaviour {



	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_01";
	// level_unlocked_02

 
	
	// set volume
	public static void SetMasterVolume (float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range.");
		}
	}
	// get volume
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	
	
	
	// unlock a level
	public static void UnlockLevel (int level){
		if (level <=  SceneManager.sceneCount - 1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); // Use 1 for true
		} else {
			Debug.LogError ("Trying to unlock level not in build order.");
		}
	}
	// check to see if level is unlocked
	public static bool IsLevelUnlocked (int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
	
		if (level <= SceneManager.sceneCount - 1){
			return isLevelUnlocked;
		}else{
			Debug.LogError ("Trying to query level not in build order.");
			return false;
		}
	}
	
	
	
	
	
	// set difficulty
	public static void SetDifficulty (float difficulty){
		if (difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty); // Use 1 for true
		} else {
			Debug.LogError ("Difficulty out of range.");
		}
	}
	// get difficulty
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
	
	
	
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
