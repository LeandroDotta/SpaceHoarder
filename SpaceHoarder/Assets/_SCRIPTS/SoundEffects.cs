using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

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

	public void Play(AudioClip clip, bool randomPitch = false, float lowPitch = 0.7f, float highPitch = 1.3f)
	{
	    if (randomPitch)
	    {
	        source.pitch = Random.Range(lowPitch, highPitch);
	    }
		source.PlayOneShot(clip);
	}
}