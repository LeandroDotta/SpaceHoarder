using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Incinerator : MonoBehaviour {

	public float CooldownCounter { get; private set; }	
	public GUIBar bar;
	public Canvas canvas;

	[Header("Sound Effects")]
	public AudioClip sfxDestroy;
	
	void Update ()
	{
		if(CooldownCounter > 0)
		{
			CooldownCounter -= Time.deltaTime;
			canvas.gameObject.SetActive (true);
			bar.UpdateCooldownBar (CooldownCounter);
			if(CooldownCounter < 0) CooldownCounter = 0;
		}

		if(CooldownCounter > 0 && canvas.gameObject.activeSelf == false) canvas.gameObject.SetActive (true);
	}

	private void OnTriggerStay(Collider other) 
	{
		if (CooldownCounter > 0) 
		{
			canvas.gameObject.SetActive (false);
			return;
		}
			

        IGrabable grabable = other.GetComponentInParent<IGrabable>();

        //if (other.CompareTag("Debri"))
        if (grabable != null)
        {

            Debug.Log("DECREMENTO: " + grabable.GetMassValue());

		    Debri debri = other.GetComponentInParent<Debri>();
            CooldownCounter = debri.IncineratorCooldown;		    
            GameManager.Instance.AddScore(debri.Score);
            GameManager.Instance.UpdateMessStatus(-grabable.GetMassValue());
			Destroy(other.transform.parent.gameObject);
			canvas.gameObject.SetActive (true);

			SoundEffects.Instance.Play(sfxDestroy);
		}
	}
}
