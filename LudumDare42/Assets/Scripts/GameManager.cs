using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Text _scoreText;
    public GUIBar GUIbar;  // Mess bar at TopRightPanel
	private int _score = 0;
    private int debriCount = 0;

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

	public void AddScore(int value)
	{
		_score += value;
		_scoreText.text = _score.ToString();

	    debriCount++;
        GUIbar.UpdateMessBar((float)debriCount);
	}


}
