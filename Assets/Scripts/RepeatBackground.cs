using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public GameManager gameManager;

    private Vector3 startPos;
    private float speed = 10;
    private float halfPoint;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        MoveLeft();
        LoopBackground();
    }

    void MoveLeft()
    {
        if (gameManager.isGameover == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    void LoopBackground()
    {
        if (transform.position.x < startPos.x - 20)
        {
            transform.position = startPos;
        }
    }
}
