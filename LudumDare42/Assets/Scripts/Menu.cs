using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Menu : MonoBehaviour {
	[SerializeField] private string _sceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Submit")) {
			SceneManager.LoadScene(_sceneName);
		}
	}
}
