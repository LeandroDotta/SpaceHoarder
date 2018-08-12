using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] VariousDebris;
    public GameObject SpawnPoint;
    public float SpawnMostWait;
    public float SpawnLeastWait;
    public int StartWait;
    public bool Stop;
    public float BurstForce = 200f;

    int _randomDebris;   

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

            _randomDebris = Random.Range(0, 3);

            float randomInterval = Random.Range(SpawnLeastWait, SpawnMostWait);
            go = (GameObject)Instantiate(VariousDebris[_randomDebris], SpawnPoint.transform.position, gameObject.transform.rotation);
            go.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(SpawnPoint.transform.forward) * BurstForce * -1);
            Debug.Log(transform.TransformDirection(SpawnPoint.transform.forward));

            yield return new WaitForSeconds(randomInterval);   
        }
    }

}
