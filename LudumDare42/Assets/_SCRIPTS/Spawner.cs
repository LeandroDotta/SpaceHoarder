using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] SmallDebris;
    private GameObject _debrisPrefabToSpawn;
    public GameObject[] MediumDebris;
    public GameObject[] LargeDebris;

    public float[] DebrisSpawnRate = {0.5f, 0.3f, 0.2f};
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

            if (random < DebrisSpawnRate[0])
            {
                // spawn small
                _debrisPrefabToSpawn = SmallDebris[Random.Range(0, SmallDebris.Length)];
                
            } else if (random < DebrisSpawnRate[0] + DebrisSpawnRate[1])
            {
                // spawn medium
                _debrisPrefabToSpawn = MediumDebris[Random.Range(0, MediumDebris.Length)];
            }
            else
            {
                // spawn large
                _debrisPrefabToSpawn = LargeDebris[Random.Range(0, LargeDebris.Length)];
            }

            Vector3 offsetVector = new Vector3(Random.Range(-0.4f,0.4f), 0, Random.Range(-0.4f, 0.4f));            
            go = (GameObject)Instantiate(_debrisPrefabToSpawn, SpawnPoint.transform.position, gameObject.transform.rotation);
            rb = go.GetComponent<Rigidbody>();
            rb.AddForce(transform.TransformDirection(SpawnPoint.transform.forward + offsetVector) * BurstForce * -1 * rb.mass);

            GameManager.Instance.UpdateMessStatus(go.GetComponent<Debri>().messValue);

            yield return new WaitForSeconds(Random.Range(SpawnLeastWait, SpawnMostWait));   
        }
    }

}
