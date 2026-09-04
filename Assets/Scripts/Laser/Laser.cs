using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float maxLifeTime = 2f;  
    private Rigidbody2D laserRb;

    public float MaxLifeTime => maxLifeTime; 

    private void Awake()
    {
        laserRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }
    /// <summary>
    /// fires the laser in the direction of the vector passed in
    /// </summary>
    /// <param name="direction"></param>
    public void fireLaser(Vector2 direction)
    {
        laserRb.linearVelocity = Vector2.zero; 
        laserRb.angularVelocity = 0f; 
        laserRb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    /// <summary>
    /// checks if the laser has collided with the bounds of the game 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bounds"))
        {
            gameObject.SetActive(false);
        }
    }
}
