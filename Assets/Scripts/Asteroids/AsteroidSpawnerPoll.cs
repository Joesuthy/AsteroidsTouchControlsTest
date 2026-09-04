using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerPoll : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab1;
    [SerializeField] private float vectorVariance = 15f;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnDistance = 15f;
    


    public static AsteroidSpawnerPoll Instance { get; private set; }



    private List<Asteroid> pooledAsteroids = new List<Asteroid>();


    private int amountInPool = 20;

    /// <summary>
    /// uses the awake function to set the instance of the class to this
    /// and add asteroids to the pool 
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        for (int i = 0; i < amountInPool; i++)
        {
            GameObject asteroid = Instantiate(asteroidPrefab1);
            Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
            asteroid.SetActive(false);
            pooledAsteroids.Add(asteroidScript);
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnAsteroid", spawnRate, spawnRate);
    }

    /// <summary>
    /// returns the first inactive asteroid in the pool
    /// </summary>
    /// <returns></returns>
    public Asteroid GetPooledAsteroid()
    {
        foreach (Asteroid asteroid in pooledAsteroids)
        {
            if (!asteroid.gameObject.activeInHierarchy)
            {
                return asteroid;
            }
        }
        return null;
    }
    /// <summary>
    /// spawns an asteroid at a random position around the centre and then moves it back to the centre
    /// </summary>
    public void SpawnAsteroid()
    {
        Asteroid asteroid = GetPooledAsteroid();

        if (pooledAsteroids != null)
        {
            //resets the asteroid to its original state becuase the Spawn mini asteroids function sets the scale to 1
            asteroid.transform.localScale = Vector3.one * 3f;
            asteroid.stopMakingMiniAsteroids = false;
            //


            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPosition = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.vectorVariance, this.vectorVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            asteroid.gameObject.SetActive(true);
            asteroid.transform.position = spawnPosition;
            asteroid.FireAsteroid(rotation * - spawnDirection);
        }
    }
    /// <summary>
    /// spawns mini asteroids at the position of the asteroid that was destroyed
    /// </summary>
    /// <param name="position"></param>
    public void SpawnMiniAsteroids(Vector2 position)
    {
        for (int i = 0; i < 4; i++)
        {
            Asteroid miniAsteroid = GetPooledAsteroid();
            if (miniAsteroid != null)
            {
                miniAsteroid.gameObject.SetActive(true);
                miniAsteroid.stopMakingMiniAsteroids = true;
                miniAsteroid.transform.localScale = Vector3.one * 1f; 
                miniAsteroid.transform.position = position;
                miniAsteroid.FireMiniAsteroids(Random.insideUnitCircle.normalized * 20f);
            }
        }

    }
}
