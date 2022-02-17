using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody playerRb;
    private Vector3 randomDeathThrow;
    private float gravityModifier = 5;
    private float downForce = 30f;
    private float upperBound = 12.7f;
    private float lowerBound = 0.5f;
    private float jumpForce = 2000;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        randomDeathThrow = Random.insideUnitCircle.normalized;
        Physics.gravity += Vector3.down * gravityModifier;
    }

    void Update()
    {
        GetInput();
        StayInBounds();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameover == false)
        {
            gameManager.isGameover = true;
            Debug.Log("GameOver!");
            Destroy(other.gameObject);
            playerRb.constraints = RigidbodyConstraints.FreezePositionZ;
            playerRb.AddTorque(Vector3.forward * 100, ForceMode.Impulse);
            playerRb.AddForce(randomDeathThrow * 400, ForceMode.Impulse);
        }
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.Space) && gameManager.isGameover == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        }
    }

    void StayInBounds()
    {
        if (transform.position.y > upperBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
            playerRb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
        }
        else if (transform.position.y < lowerBound)
        {
            transform.position = new Vector3(transform.position.x, lowerBound, transform.position.z);
        }
    }
}
