using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField] private Text _txtScore;
	private int _score = 0;
	// Use this for initialization
	void Start () {
		_txtScore.text = "Score: " + _score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore(int value){
		_score += value;
		_txtScore.text = "Score: " + _score;
	}
}
