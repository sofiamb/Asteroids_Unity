using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipController : MonoBehaviour
{
    [Header("Speed Settings")]
    public float speed; // La velocidad de movimiento de la nave
    public float maxSpeed; // Velocidad maxima de la nave
    public float drag;//drag para reducir la velocidad de la nave
    public float angularSpeed;// velocidad angular
  
    [Header("Laser Settings")]

    public Vector2 laserPosition;
    public float offsetLaser;
    public GameObject laserPrefab;
    public float shootRate = 0.2f;
  


    private Rigidbody2D shipRB; // referencia al rigidbody
    private float vertical;
    private float horizontal;
    private bool shooting;
    private bool canShoot = true;
    private UIController UIController;


    private void Start()
    {
        shipRB = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D.
        shipRB.drag = drag;
        UIController = GameObject.Find("Canvas").GetComponent<UIController>();
        initialSetup(new Vector3(0, 0, 0));
    }
    private void Update()
    {
        vertical = InputManager.Vertical;
        horizontal = InputManager.Horizontal;
        shooting = InputManager.Fire;
        Rotate();
        
    }
    private void FixedUpdate()
    {

        Move();
        Shoot();
    }
   
    public void Move()
    {
        var fowardMotor = Mathf.Clamp(vertical, 0f, 1f);
        shipRB.AddForce(transform.up * speed * fowardMotor);
        
        if (shipRB.velocity.magnitude > maxSpeed)
            shipRB.velocity = shipRB.velocity.normalized * maxSpeed;

       
    }
    public void initialSetup(Vector3 initialPosition) {

        // Asigna la posición inicial de la nave
        transform.localPosition = initialPosition;

    }

    private void Rotate() {
        if (horizontal == 0) 
            return;

        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);
      
    }
    private void Shoot() {
        
        if (shooting && canShoot)
           StartCoroutine(FireRate());
    }

    private IEnumerator FireRate() {
        canShoot = false;

        var laserPosition = transform.up * offsetLaser + transform.position;
        var laser = Instantiate(laserPrefab, laserPosition, transform.rotation);
        
        Destroy(laser, 3);
        
        yield return new WaitForSeconds(shootRate);
        
        canShoot = true;
    }

    public void Lose() {
        initialSetup(new Vector3(0, 0, 0));
        UIController.ShowPanel();
        UIController.totalPoints = 0;
        UIController.setPoints(0);
    }

    

}
