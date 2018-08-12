using UnityEngine;

public enum Size
{
    Small,
    Medium,
    Large
};

public class Debri : MonoBehaviour, IGrabable
{
    public Size Size;
    public float PlayerSpeedMultiplier = 1;
}
