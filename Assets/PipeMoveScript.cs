using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public float deadZone = -25;
    public float speedRateIncrease = 2.5f;
    public float maxSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PipeMoveScript started. Initial moveSpeed: " + moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the pipe to the left
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; 

        // Increment the speed and cap it at maxSpeed
        moveSpeed += speedRateIncrease * Time.deltaTime;
        moveSpeed = Mathf.Min(moveSpeed, maxSpeed);
  

        // Check if the pipe has moved past the dead zone
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
       
    }
}
