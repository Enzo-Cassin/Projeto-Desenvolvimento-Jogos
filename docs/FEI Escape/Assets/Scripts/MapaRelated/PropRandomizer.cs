using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;


    void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        //Spawn a random prop at every spawn point
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
        }
    }
}