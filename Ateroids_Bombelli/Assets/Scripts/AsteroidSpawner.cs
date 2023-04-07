using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Asteroids Prefabs")]
    /*public GameObject asteroidBigPrefab;
    public GameObject asteroidMediumPrefab;
    public GameObject asteroidSmallPrefab;
    */
    public GameObject [] asteroidsPrefab;

    [Header("Asteroids Settings")]
    public float timeToSpawn;
    public Transform[] spawnPoints;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(asteroidsPrefab[Random.Range(0, asteroidsPrefab.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(timeToSpawn);
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
