using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 0.0f;

    private Rigidbody2D rigidBody;
    private Vector2 Velocity;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            Velocity = new Vector2(-movementSpeed, 0);
        else if (Input.GetKey(KeyCode.D))
            Velocity = new Vector2(movementSpeed, 0);
        else if (Input.GetKey(KeyCode.W))
            Velocity = new Vector2(0, movementSpeed);
        else if (Input.GetKey(KeyCode.S))
            Velocity = new Vector2(0, -movementSpeed);
        else
            Velocity = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + Velocity * Time.fixedDeltaTime);
    }


}