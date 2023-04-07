using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
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
}
