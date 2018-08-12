using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject[] variousDebris;
    public GameObject[] spawnPlace;
    public GameObject referenceForSpawner;
    public Vector3 referenceModifier;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;


    int randomDebris;
    int randomSpawnPlace;


	void Start () {

        StartCoroutine(waitSpawner());

	}
	

	void Update () {

        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
		
	}


    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randomDebris = Random.Range(0, 3);
            randomSpawnPlace = Random.Range(0, 2);
            referenceModifier = new Vector3(0, 0, 0);




            if (spawnPlace[randomSpawnPlace].transform.position.x > referenceForSpawner.transform.position.x)
            {
                referenceModifier.x = 2;
                referenceModifier.y = 0;
                referenceModifier.z = 0;
            }
            else if (spawnPlace[randomSpawnPlace].transform.position.y > referenceForSpawner.transform.position.y)
            {
                referenceModifier.x = 0;
                referenceModifier.y = -2;
                referenceModifier.z = 0;
            }


            //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(variousDebris[randomDebris], spawnPlace[randomSpawnPlace].transform.position + referenceModifier, gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);

            Debug.Log("Spawn: " + spawnPlace[randomSpawnPlace].transform.position);



            
        }
    }


}
