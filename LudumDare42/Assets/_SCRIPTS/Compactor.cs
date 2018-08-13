using System.Collections;
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

    [Header("Sound Effects")]
    public AudioClip sfxSpawn;

    public float CooldownCounter { get; private set; }
    public bool IsCoolingDown { get{ return CooldownCounter > 0; } }

    void Update()
    {
        if (CooldownCounter > 0)
        {
            if (CooldownCounter > 0)
            {
                CooldownCounter -= Time.deltaTime;
                bar.UpdateCooldownBar(CooldownCounter);

                if (CooldownCounter < 0)
                    CooldownCounter = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collided");
        if (CooldownCounter > 0)
            return;

        if (other.CompareTag("Debri"))
        {
            Debri debri = other.GetComponentInParent<Debri>();

			if(debri.IsGrabbed || debri.Size == Size.Small)
				return;
			
			CooldownCounter = debri.CompactorCooldown;
			StartCoroutine(SpawnCoroutine(debri.Size, debri.CompactorCooldown));

            Destroy(other.transform.parent.gameObject);

            canvas.gameObject.SetActive(true);
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

        SoundEffects.Instance.Play(sfxSpawn);

        canvas.gameObject.SetActive(false);
    }
}