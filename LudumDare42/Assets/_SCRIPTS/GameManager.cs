using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _WaveText;

	public enum StateMachine { Title, Game, Pausa, GameOver };
	public StateMachine state = StateMachine.Title;

    public GUIBar MessBar;  // Mess bar at TopRightPanel
    public Spawner[] waveSpawn;
    private int _score = 0;
    private int debriCount = 0;
    private int actualMessValue = 0;
    private int accruedMessValue = 0;

    private int _waveNumber = 1;
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
        MessBar.MaxRawValue = _maxMessValue;
        _WaveText.text = _waveNumber.ToString();
        //MessBar.UpdateMess();
    }

	public void AddScore(int value)
	{
		_score += value;
		_scoreText.text = _score.ToString();
	}

    public void UpdateMessStatus(int value)
    {

        //Debug.Log("INCREMENTO: " + value + " - TOTAL: " + (actualMessValue + value));
        if (value > 0)
        {
            accruedMessValue += value;
        }

        actualMessValue += value;
        MessBar.UpdateMess((float)actualMessValue);

        if (IsGameOver())
        {
            Debug.Log("GAME OVE!!!!!!");
        }

        if (EndWave())
        {
            StartNewWave();
        }

    }

    bool IsGameOver()
    {
        return actualMessValue > _maxMessValue;
    }

    bool EndWave()
    {
        return accruedMessValue > _totalWaveMessValue;
    }

    public void StartNewWave()
    {

        foreach (var Spawner in waveSpawn)
        {
            Spawner.SpawnLeastWait *= 0.90f;
            Spawner.SpawnMostWait *= 0.90f;
            Spawner.DebrisSpawnRate[0] -= 0.05f;
            Spawner.DebrisSpawnRate[1] += 0.03f;
            Spawner.DebrisSpawnRate[2] += 0.02f;
        }

        _totalWaveMessValue = _totalWaveMessValue * 1.5f;

        accruedMessValue = 0;
        actualMessValue = 0;
        _waveNumber += 1;

        MessBar.setBarToZero();

        _WaveText.text = _waveNumber.ToString();

        Debug.Log("WAVE: " + _waveNumber);
    }

}
