using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private Sprite[] sprites;


    private Rigidbody2D asteroidRb;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2;

    public bool stopMakingMiniAsteroids = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        asteroidRb = GetComponent<Rigidbody2D>();
        collider2 = GetComponent<Collider2D>();
    }
    /// <summary>
    /// function contains the logic of what to do depending oin what hit the asteroid using tags
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Laser") && stopMakingMiniAsteroids == false)
        {
            gameObject.SetActive(false);
            AsteroidSpawnerPoll.Instance.SpawnMiniAsteroids(gameObject.transform.position);
            collision.gameObject.SetActive(false);
            ScoreCounter.Instance.AddScore(1);
        }
        if(collision.gameObject.CompareTag("Laser") && stopMakingMiniAsteroids == true )
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            ScoreCounter.Instance.AddScore(3);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //logic to hurt the player is in PlayerController script

        }
        if (collision.gameObject.CompareTag("AsteroidBlock"))
        {
            gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// function to set the asteroid sprite from the array of sprites
    /// then fires the asteroid in the direction of the vector passed in
    /// </summary>
    /// <param name="direction"></param>
    public void FireAsteroid(Vector2 direction)
    {
       
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));

        asteroidRb.AddForce(direction * speed);

    }
    /// <summary>
    /// function to set the asteroid sprite from the array of sprites
    /// then fires the asteroid in the direction of the vector passed in
    /// </summary>
    /// <param name="position"></param>
    public void FireMiniAsteroids(Vector2 position)
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));

        asteroidRb.AddForce(position * speed);

    }
    



}








