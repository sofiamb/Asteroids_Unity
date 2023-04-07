using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Asteroid type Settings")]
    public AsteroidSize asteroidSize;
    public enum AsteroidSize
    {
        bigAsteroid,
        mediumAsteroid,
        smallAsteroid
    }
    
    public int childAsteroidsNumber;

    [Header("Speed Settings")]
    public float speed;
    private Rigidbody2D AsteroidRB;
    private UIController UIController;

    void Start()
    {
        AsteroidRB = GetComponent<Rigidbody2D>();
        AsteroidRB.drag = 0;
        AsteroidRB.angularDrag = 0;

        AsteroidRB.velocity = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), 0).normalized * speed;
        AsteroidRB.angularVelocity = Random.Range(-50, 50);
        UIController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser")) {
            UIController.setPoints(10);
            if (asteroidSize == AsteroidSize.bigAsteroid)
            {
                AsteroidSpawner spawner = GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>();

                for (int i = 0; i < childAsteroidsNumber; i++) {
                    GameObject MediumAsteroid = Instantiate(spawner.asteroidsPrefab[1]);
                    MediumAsteroid.transform.position = new Vector3(this.transform.position.x + Random.Range(-1.5f, 1.5f), this.transform.position.y + Random.Range(-1.5f, 1.5f), 0);
                }
            }

            if (asteroidSize == AsteroidSize.mediumAsteroid)
            {
                AsteroidSpawner spawner = GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>();

                for (int i = 0; i < childAsteroidsNumber; i++)
                {
                    GameObject smallAsteroid = Instantiate(spawner.asteroidsPrefab[2]);
                    smallAsteroid.transform.position = new Vector3(this.transform.position.x + Random.Range(-1.5f, 1.5f), this.transform.position.y + Random.Range(-1.5f, 1.5f), 0);
                }
            }


            Destroy(gameObject);
            Destroy(collision.gameObject);

           
        }

        if (collision.CompareTag("playerShip")) {
            var asteroids = FindObjectsOfType<Asteroid>();
            for (int i = 0; i < asteroids.Length; i++) {
                Destroy(asteroids[i].gameObject);
            }

            collision.GetComponent<ShipController>().Lose();
        
        }
    }
}
