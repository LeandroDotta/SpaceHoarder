using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Push : MonoBehaviour 
{
	public float Force = 200f;
	public float Cooldown = 2f;
	[SerializeField] private Collider _trigger;
	[SerializeField] private Animator anim;

	public float CooldownCounter { get; private set; }

	private void Start() 
	{
		_trigger.enabled = false;
		CooldownCounter = Cooldown;
	    //if (_trigger == null)
	    //{
	    //    _trigger = GetComponentInChildren<Collider>();
	    //}
	}

	private void Update() 
	{
		if(CooldownCounter > 0)
		{
			CooldownCounter -= Time.deltaTime;

			if(CooldownCounter < 0)
				CooldownCounter = 0;
		}
	}
	public void Apply()
	{
		if(CooldownCounter > 0)
			return;

		anim.SetTrigger("Push");
		_trigger.enabled = true;
		StartCoroutine("DisableCoroutine");
		CooldownCounter = Cooldown;
	}

	private IEnumerator DisableCoroutine()
	{
		yield return new WaitForSeconds(0.1f);

		_trigger.enabled = false;
	}

	private void OnTriggerStay(Collider other) 
	{
		if(other.CompareTag("Debri"))
		{
			Rigidbody rb = other.GetComponentInParent<Rigidbody>();
			if(rb != null)
				rb.AddForce(transform.forward * Force, ForceMode.Impulse);
		}	    
	}
}
