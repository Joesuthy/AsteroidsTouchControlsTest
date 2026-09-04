using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPool : MonoBehaviour
{
    #region Singleton
    public static LaserPool Instance { get; private set; }
    private List<Laser> pooledLasers = new List<Laser>();
    private int amountInPool = 20;

    [SerializeField] private GameObject laserPrefab;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        for (int i = 0; i < amountInPool; i++)
        {
            GameObject laser = Instantiate(laserPrefab);
            Laser laserScript = laser.GetComponent<Laser>();
            laser.SetActive(false);
            pooledLasers.Add(laserScript);



        }

    } 
    #endregion


 
 

    public Laser GetPooledLaser()
    {
        foreach (Laser laser in pooledLasers)
        {
            if (!laser.gameObject.activeInHierarchy)
            {
                return laser;
            }
        }
        return null;
    }


   
}
