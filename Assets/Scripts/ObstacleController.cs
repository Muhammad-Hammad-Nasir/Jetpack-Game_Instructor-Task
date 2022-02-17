using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float speed = 10;
    private float leftLimit = -14;

    void Update()
    {
        MoveLeft();
        LeftBound();
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);  // Move Left
    }

    void LeftBound()
    {
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
