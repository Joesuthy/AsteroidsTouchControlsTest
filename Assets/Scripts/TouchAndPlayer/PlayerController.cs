
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 2000f;
    [SerializeField] private float drag = 0.1f;
    [SerializeField] private LaserPool laserPool;
    [SerializeField] private float blinkDuration = 0.2f;
    [SerializeField] private int blinkCount = 6;
    [SerializeField] private int lives = 4;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private List<GameObject> lifeImages = new List<GameObject>();

    private SpriteRenderer shipSpriteRenderer;
    private BoxCollider2D boxCollider;
    private Vector2 movement;
    private Rigidbody2D rb;

    

    private void Awake()
    {
        shipSpriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = drag;
    }
    /// <summary>
    /// Subscribes to the swipe and tap events from the TouchManager and TapManager
    /// </summary>
    private void OnEnable()
    {
        TouchManager.SwipeEvent += MoveShip;
        TapManager.TapEvent += OnTapDetected;
    }
    /// <summary>
    /// Unsubscribes from the swipe and tap events from the TouchManager and TapManager
    /// </summary>
    private void OnDisable()
    {
        TouchManager.SwipeEvent -= MoveShip;
        TapManager.TapEvent -= OnTapDetected;
    }
    /// <summary>
    /// FixedUpdate is called every fixed framerate frame, using for the movement of the player because it is physics based 
    /// </summary>
    private void FixedUpdate()
    {
        movement = InputManager.Movement;

        if (movement != Vector2.zero)
        {
            RotateAndMove(movement);
        }
    }
    /// <summary>
    /// Checks if the player has collided with an asteroid and if so, reduces the lives of the player by 1
    /// then if the player lives is less than 0, the game is over
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && lives > 0)
        {
            StartCoroutine(BlinkOnHit());
            lives--;
            if (lifeImages.Count > 0)
            {
                GameObject lastInList = lifeImages[lifeImages.Count -1];
                lastInList.SetActive(false);
                lifeImages.RemoveAt(lifeImages.Count - 1);
            }
        }
        if (collision.gameObject.CompareTag("Asteroid") && lives <= 0)
        {
            endGameScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }


    /// <summary>
    /// Moves the ship in the direction of the swipe
    /// </summary>
    /// <param name="swipeDirection"></param>
    private void MoveShip(Vector2 swipeDirection)
    {
        RotateAndMove(swipeDirection);
    }
    /// <summary>
    /// Rotates the ship in the directio moves the ship in that direction
    /// </summary>
    /// <param name="direction"></param>
    private void RotateAndMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            rb.linearVelocity = direction * moveSpeed * Time.deltaTime;
        }
    }
    /// <summary>
    /// Detects the tap on the screen and fires the laser in the direction of the ship
    /// </summary>
    /// <param name="tapPosition"></param>
    private void OnTapDetected(Vector2 tapPosition)
    {
        FireLaser();
    }
    /// <summary>
    /// Fires the laser in the direction of the ship
    /// </summary>
    public void FireLaser()
    {
        Vector2 fireDirection = transform.up.normalized;
        Vector2 firePosition = (Vector2)transform.position + fireDirection * 1f;

        Laser laser = laserPool.GetPooledLaser();

        if (laser != null)
        {
            laser.transform.position = firePosition;
            laser.transform.rotation = transform.rotation;
            laser.gameObject.SetActive(true);
            laser.fireLaser(fireDirection);
        }
    }
    /// <summary>
    /// Blinks the ship when it is hit by an asteroid
    /// </summary>
    /// <returns></returns>
    public IEnumerator BlinkOnHit()
    {
        

        for (int i = 0; i < blinkCount; i++)
        {
            shipSpriteRenderer.enabled = !shipSpriteRenderer.enabled;
            boxCollider.enabled= false;
            yield return new WaitForSeconds(blinkDuration);
        }

        shipSpriteRenderer.enabled = true;
        boxCollider.enabled = true;
        

    }
}
