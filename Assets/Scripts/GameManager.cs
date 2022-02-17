using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hurdle;
    public bool isGameover;
 
    private Vector3 hurdlePos;
    private float yUpperLimit = 12.5f;
    private float yLowerLimit = 0.5f;
    private float xSpawnPos = 14;
    private float delay = 1f;
    private float repeatRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnHurdles", delay, repeatRate);
    }

    void SpawnHurdles()
    {
        if (isGameover == false)
        {
            float randomNum = Random.Range(yLowerLimit, yUpperLimit);
            hurdlePos = new Vector3(xSpawnPos, randomNum, 0);

            Instantiate(hurdle, hurdlePos, hurdle.transform.rotation);
        }
    }
}
