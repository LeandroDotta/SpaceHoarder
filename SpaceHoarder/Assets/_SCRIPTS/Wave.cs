using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Space Hoarder/Wave", order = 1)]
public class Wave : ScriptableObject
{    
    public int Id;
    public int MaxMessValue;
    public int DebrisTotal;

    [Header("Spawn Rate")]
    public float rateDebriSmall = 0.7f;
    public float rateDebriMedium = 0.2f;
    public float rateDebriLarge = 0.1f;

    [Header("Spawn Wait Time")]
    public float spawnMostWait = 2;
    public float spawnLeastWait = 1;
}
