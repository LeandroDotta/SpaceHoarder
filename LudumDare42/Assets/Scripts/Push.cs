using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour 
{
	public float force;
	public float cooldown;
	[SerializeField] private Collider trigger;

	public float CooldownCounter { get; private set; }

	private void Start() 
	{
		trigger.enabled = false;
		CooldownCounter = cooldown;
	}

	private void Update() 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Apply();
		}

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

		trigger.enabled = true;
		StartCoroutine("DisableCoroutine");
		CooldownCounter = cooldown;
	}

	private IEnumerator DisableCoroutine()
	{
		yield return new WaitForSeconds(0.1f);

		trigger.enabled = false;
	}

	private void OnTriggerStay(Collider other) 
	{
		if(other.CompareTag("Debri"))
		{
			Rigidbody rb = other.GetComponentInParent<Rigidbody>();
			if(rb != null)
				rb.AddForce(transform.forward * force, ForceMode.Impulse);
		}
	}
}