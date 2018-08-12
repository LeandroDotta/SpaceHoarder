using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] VariousDebris;
    public float[] DebrisSpawnRate;
    public GameObject SpawnPoint;
    public float SpawnMostWait;
    public float SpawnLeastWait;
    public int StartWait;
    public bool Stop;
    public float BurstForce = 200f;

    void Start ()
	{
        StartCoroutine(WaitSpawner());
	}	

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(StartWait);

        while (!Stop)
        {
            Rigidbody rb;
            GameObject go;
            
            float random = Random.Range(0f, 1f);
            int _randomDebrisIndex;

            if (random < DebrisSpawnRate[0])
            {
                _randomDebrisIndex = 0;


            } else if (random < DebrisSpawnRate[0] + DebrisSpawnRate[1])
            {
                _randomDebrisIndex = 1;

            }
            else
            {
                _randomDebrisIndex = 2;

            }
            float randomInterval = Random.Range(SpawnLeastWait, SpawnMostWait);
            go = (GameObject)Instantiate(VariousDebris[_randomDebrisIndex], SpawnPoint.transform.position, gameObject.transform.rotation);
            rb = go.GetComponent<Rigidbody>();
            rb.AddForce(transform.TransformDirection(SpawnPoint.transform.forward) * BurstForce * -1 * rb.mass);

            GameManager.Instance.UpdateMessStatus(go.GetComponent<Debri>().messValue);

            yield return new WaitForSeconds(randomInterval);   
        }
    }

}
