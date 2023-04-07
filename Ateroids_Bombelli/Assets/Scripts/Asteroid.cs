using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid type Settings")]
    public bool isAsteroidBig;

    [Header("Speed Settings")]
    public float speed;
    private Rigidbody2D AsteroidRB;

    void Start()
    {
        AsteroidRB = GetComponent<Rigidbody2D>();
        AsteroidRB.drag = 0;
        AsteroidRB.angularDrag = 0;

        AsteroidRB.velocity = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), 0).normalized * speed;
        AsteroidRB.angularVelocity = Random.Range(-50, 50);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser")) {
            if (isAsteroidBig)
            {
                AsteroidSpawner spawner = GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>();

                GameObject smallAsteroid1 = Instantiate(spawner.asteroidSmallPrefab);
                smallAsteroid1.transform.position = new Vector3(this.transform.position.x + Random.Range(-1.5f, 1.5f), this.transform.position.y + Random.Range(-1.5f, 1.5f), 0);

                GameObject smallAsteroid2 = Instantiate(spawner.asteroidSmallPrefab);
                smallAsteroid2.transform.position = new Vector3(this.transform.position.x + Random.Range(-1.5f, 1.5f), this.transform.position.y + Random.Range(-1.5f, 1.5f), 0);

            }
           

                Destroy(gameObject);
                Destroy(collision.gameObject);

           
        }
    }
}
