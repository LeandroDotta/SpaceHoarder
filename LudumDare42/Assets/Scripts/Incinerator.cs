using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incinerator : MonoBehaviour {

	public float CooldownCounter { get; private set; }	
	
	void Update ()
	{
		if(CooldownCounter > 0)
		{
			CooldownCounter -= Time.deltaTime;

			if(CooldownCounter < 0)
				CooldownCounter = 0;
		}
	}

	private void OnTriggerStay(Collider other) {
		if (CooldownCounter > 0)
			return;

		if(other.CompareTag("Debri"))
		{
		    Debri debri = other.GetComponentInParent<Debri>();
            CooldownCounter = debri.IncineratorCooldown;		    
            GameManager.Instance.AddScore(debri.Score);
			Destroy(other.transform.parent.gameObject);
		}
	}
}
