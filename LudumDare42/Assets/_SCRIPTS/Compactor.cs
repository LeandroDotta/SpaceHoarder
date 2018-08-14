using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Compactor : MonoBehaviour
{
    public Transform spawnPoint;
    public float exitForce;
    public CooldownBar cooldown;

    [Header("Prefabs")]
    public GameObject compactedSmall;
    public GameObject compactedMedium;

    [Header("Effects")]
    public AudioClip SfxSpawn;
    public ParticleSystem CompactorParticleSystem;

    public float CooldownCounter { get; private set; }
    public bool IsCoolingDown { get{ return CooldownCounter > 0; } }

    private void Awake()
    {
        Assert.IsNotNull(cooldown);
    }

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

			if(debri.IsGrabbed || debri.Size == Size.Small)
				return;

            // Compactor Particle System
            GameObject particleGO = Instantiate(CompactorParticleSystem.gameObject, debri.transform.position, Quaternion.identity) as GameObject;
            Destroy(particleGO, 1f);

            CooldownCounter = debri.CompactorCooldown;
            cooldown.Show(debri.CompactorCooldown); // Show cooldown UI
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

        SoundEffects.Instance.Play(SfxSpawn, true);
    }
}