using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerArea : MonoBehaviour
{
    public GameObject[] VariousDebris;
    public float[] DebrisSpawnRate;
    // public GameObject SpawnPoint;
    public float SpawnMostWait;
    public float SpawnLeastWait;
    public int StartWait;
    public bool Stop;
    public float BurstForce = 200f;

    public Bounds area;

    void Start()
    {
        area.center = transform.position;
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
            }
            else if (random < DebrisSpawnRate[0] + DebrisSpawnRate[1])
            {
                _randomDebrisIndex = 1;
            }
            else
            {
                _randomDebrisIndex = 2;
            }
            float randomInterval = Random.Range(SpawnLeastWait, SpawnMostWait);

            Vector3 position = new Vector3(Random.Range(area.min.x, area.max.x), area.center.y, Random.Range(area.min.z, area.max.z));
            Vector3 rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            go = (GameObject)Instantiate(VariousDebris[_randomDebrisIndex], position, Quaternion.Euler(rotation));
            go.SetActive(true);

            // rb = go.GetComponent<Rigidbody>();
            // rb.AddForce(transform.TransformDirection(SpawnPoint.transform.forward) * BurstForce * -1 * rb.mass);
            // Debug.Log(transform.TransformDirection(SpawnPoint.transform.forward));
            

            yield return new WaitForSeconds(randomInterval);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, area.size);
    }
}
