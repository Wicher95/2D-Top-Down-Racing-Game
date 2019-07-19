using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carHorsePower;
    float speed, direction, steeringAmount;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * carHorsePower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * speed);

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }
}
