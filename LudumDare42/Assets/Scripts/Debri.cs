using UnityEditor;
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
    public float IncineratorCooldown = 1.0f;
    public float CompactorCooldown = 1.0f;
    public bool Compacted = false;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;

    [SerializeField] private int _score = 1;

    void Start()
    {
        defaultMaterial = this.GetComponentInChildren<Renderer>().sharedMaterial;
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public void SetHighlighted(bool highlighted)
    {
        if (highlighted)
        {
            if (highlightMaterial == null)
            {
                highlightMaterial = defaultMaterial;
                Debug.LogWarning("HighlightMaterial not set");
            }
            this.GetComponentInChildren<Renderer>().sharedMaterial = highlightMaterial;
        }
        else
        {
            this.GetComponentInChildren<Renderer>().sharedMaterial = defaultMaterial;
        }
    }
}
