using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incinerator : MonoBehaviour {

	public float CooldownCounter { get; private set; }
	GameManager _gameManager;

	// Use this for initialization
	void Start () {
		_gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
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

		if(other.CompareTag("Debri")) {
			CooldownCounter = other.GetComponentInParent<Debri>().IncineratorCooldown;
			Destroy(other.transform.parent.gameObject);
			_gameManager.AddScore(1);
		}
	}
}
