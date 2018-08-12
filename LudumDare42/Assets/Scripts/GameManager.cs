using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Text _scoreText;
    public GUIBar MessBar;  // Mess bar at TopRightPanel
	private int _score = 0;
    private int debriCount = 0;
    private int messValue = 0;

    private int _maxMessValue = 100;

    public int MaxMessValue {
        get { return _maxMessValue; }
        set { _maxMessValue = value; }
    }

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

        Init();
    }


    public void Init()
    {
        MessBar.MaxRawValue = _maxMessValue;
    }

	public void AddScore(int value)
	{
		_score += value;
		_scoreText.text = _score.ToString();
	}

    public void UpdateMessStatus(int value)
    {

        Debug.Log("INCREMENTO: " + messValue);

        messValue += value;
        MessBar.UpdateMess(messValue);

        //if (IsGameOver())
        //{
            
        //}
    }

    bool IsGameOver()
    {
        return messValue > _maxMessValue;
    }




}
