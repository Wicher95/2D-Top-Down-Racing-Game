using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    public float carHorsePower;
    public TrailRenderer[] trails;

    float torque = -150f;
    float speed, steeringAmount;
    float driftSticky = 0.6f;
    float driftSlippy = 1f;
    float maxStickyVelocity = 0.7f;
    bool inDrift;
    Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
        inDrift = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(inDrift)
        {
            for (int i = 0; i < trails.Length; i++)
            {
                trails[i].enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < trails.Length; i++)
            {
                trails[i].enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(transform.up * carHorsePower);
        }
        else if(Input.GetButton("Break"))
        {
            rb.AddForce(-transform.up * carHorsePower / 2);
        }

        steeringAmount = IsDrivingForward() ? Input.GetAxis("Horizontal") : -Input.GetAxis("Horizontal");

        float t = Mathf.Lerp(0, torque, rb.velocity.magnitude);
        rb.angularVelocity = steeringAmount * t;


        float driftFactor = RightVelocty().magnitude > maxStickyVelocity ? driftSlippy : driftSticky;
        if (Input.GetButton("HandBreak")) { driftFactor = driftSlippy; rb.drag = 3; }
        else rb.drag = 1;
        rb.velocity = ForwardVelocity() + RightVelocty() * driftFactor;

        inDrift = driftFactor == driftSlippy ? true : false;
    }

    private Vector2 ForwardVelocity()
    {
        // Dot - How much of the velocity is 'going up'
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }
    private Vector2 RightVelocty()
    {
        // Dot - How much of the velocity is 'going right'
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }

    private bool IsDrivingForward()
    {
        return Vector2.Dot(transform.up.normalized, rb.velocity.normalized) >= 0 ? true : false; 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FinishLine"))
        {
            RaceController.instance.StartRace();
        }
    }
}
