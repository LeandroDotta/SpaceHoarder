using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//public enum StateMachine { Title, Game, Pause, GameOver };
	//public StateMachine state = StateMachine.Title;

    [Header("UI Panels")]
    public GUIBar MessPanel;
    public RectTransform CenterPanel;
    [SerializeField] private Text _waveText;
    [SerializeField] private Text _scoreText;

    [Header("Waves ScriptableObjects")]
    public Wave[] Waves;

    [Header("Spawners")]
    public Spawner[] Spawners;

    private Wave _currentWave;
    private int _score = 0;
    private int _currentDebriCount = 0;    
    private int _currentMessValue = 0;
    private int _currentWaveIndex = 0;
    private int _maxMessValue = 25;
    private float _totalWaveMessValue = 25;

    public int MaxMessValue {
        get { return _maxMessValue; }
        set { _maxMessValue = value; }
    }

    public float totalWaveMessValue
    {
        get { return _totalWaveMessValue; }
        set { _totalWaveMessValue = value; }
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
        StartNextWave();
        MessPanel.MaxRawValue = _maxMessValue;
        _waveText.text = _currentWaveIndex.ToString();
        MessPanel.UpdateMess(_currentMessValue);
    }

	public void AddScore(int value)
	{
		_score += value;
		_scoreText.text = _score.ToString();
	}

    public void UpdateMessValue(int value)
    {
        if (value > 0)
        {
            _currentMessValue += value;
        }

        if (IsGameOver())
        {
            GameOver();
            return;
        }

        if (HasWavedEnded())
        {
            StartNextWave();
            return;
        }
        
        MessPanel.UpdateMess((float)_currentMessValue);
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER!");
        // TODO show UI GameOver with Restart and Quit buttons
    }

    bool IsGameOver()
    {
        return _currentMessValue > _currentWave.MaxMessValue;
    }

    bool HasWavedEnded()
    {
        return _currentDebriCount > _currentWave.DebrisTotal;
    }

    public void StartNextWave()
    {
        // Check if we are in the last Wave, or the first one
        if (_currentWaveIndex == Waves.Length) { GameOverWin(); return; }
        if (_currentWaveIndex != 0) { _currentWaveIndex++; }
        
        // Set Wave values
        _currentWave = Waves[_currentWaveIndex];
        _waveText.text = _currentWave.Id.ToString();
        _totalWaveMessValue = _currentWave.MaxMessValue;

        _currentMessValue = 0;
        _currentDebriCount = 0;               

        //MessPanel.SetBarToZero();        

        StartCoroutine(ShowCenterPanelForSeconds("Wave " + _currentWaveIndex + 1));
    }

    /// <summary>
    /// Shows the CenterPanel for a couple seconds, default is 3s
    /// </summary>
    public IEnumerator ShowCenterPanelForSeconds(string textToShow, float timeToShow = 3f)
    {
        _waveText.text = "";
        _waveText.text = textToShow;
        CenterPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeToShow);
        CenterPanel.gameObject.SetActive(false);
    }

    private void HideWaveUI()
    {
        CenterPanel.gameObject.SetActive(false);
    }

    private void GameOverWin()
    {
        ShowCenterPanelForSeconds("YOU WIN!", 5f);
        // TODO if Reach last end show YOU WIN Screen!        
    }
}
