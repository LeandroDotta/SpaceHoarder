﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compactor : MonoBehaviour
{
    public Transform spawnPoint;
    public float exitForce;
	public GUIBar bar;
	public Canvas canvas;

    [Header("Prefabs")]
    public GameObject compactedSmall;
    public GameObject compactedMedium;

    public float CooldownCounter { get; private set; }

    void Update()
    {
        if (CooldownCounter > 0)
        {
            if (CooldownCounter > 0)
            {
                CooldownCounter -= Time.deltaTime;

                if (CooldownCounter < 0)
                    CooldownCounter = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (CooldownCounter > 0)
            return;

        if (other.CompareTag("Debri"))
        {
            Debri debri = other.GetComponentInParent<Debri>();

			if(debri.Size == Size.Small)
				return;
			
			CooldownCounter = debri.CompactorCooldown;
			StartCoroutine(SpawnCoroutine(debri.Size, debri.CompactorCooldown));

            Destroy(other.transform.parent.gameObject);
        }
    }

    private IEnumerator SpawnCoroutine(Size size, float cooldown)
    {
		yield return new WaitForSeconds(cooldown);

        Vector3 rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        GameObject instance = Instantiate(size == Size.Large ? compactedMedium : compactedSmall);
        instance.transform.position = spawnPoint.position;
        instance.transform.rotation = Quaternion.Euler(rotation);
        instance.SetActive(true);

        Rigidbody rb = instance.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(spawnPoint.forward * exitForce, ForceMode.Impulse);
    }
}