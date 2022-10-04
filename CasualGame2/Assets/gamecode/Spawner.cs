using System.Collections.Generic;
using UnityEngine;

// Spawner is responsible to pool all the gameobjects to be spawned
// and to spawn them randomly with specified delay.
// This script does not responsible for despawning.
public class Spawner : MonoBehaviour
{
    public GameObject[] objectPool;

    public float spawnDelay = 3f;
    float elapsedtime = 0f;

    // to automatically assign objects to pool
    public string tag1 = "organik", tag2 = "nonorganik";

    // Start is called before the first frame update
    void Start()
    {
        // If pool hasn't been filled, try to do it automatically.
        if (objectPool.Length < 1 && tag1 != "" && tag2 != "")
        {
            List<GameObject> items = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag1));
            items.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag(tag2)));
            objectPool = items.ToArray();
        }

        //deactivate every objects in pool
        foreach (GameObject go in objectPool)
        {
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Spawning with delay
        elapsedtime += Time.deltaTime;
        if (elapsedtime > spawnDelay)
        {
            elapsedtime = 0f;
            Spawn();
        }
    }

    public void Spawn()
    {
        // Pick random index
        int sp = Random.Range(0, objectPool.Length - 1);

        // Check if the object has not spawned and not active
        if (!objectPool[sp].activeInHierarchy)
        {
            // Move object to spawner and activate.
            objectPool[sp].transform.position = transform.position;
            objectPool[sp].SetActive(true);
        }
    }
}
