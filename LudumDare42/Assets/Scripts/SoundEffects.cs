using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

    public static SoundEffects Instance { get; private set; }

	private AudioSource source;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

	private void Start() 
	{
		source = GetComponent<AudioSource>();	
	}

	public void Play(AudioClip clip)
	{
		source.PlayOneShot(clip);
	}
}