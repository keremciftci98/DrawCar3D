using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireScript : MonoBehaviour
{
    public float turnSpeed;
    public float speed;
    private Rigidbody rb;
    public float velo;
    public float maxSpeed;
    public Transform jant;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jant.Rotate(0, -1 * turnSpeed * Time.deltaTime, 0);
        velo = rb.velocity.magnitude;
        if (velo < maxSpeed)
        {
            rb.AddForce(Vector3.right * speed);
        }
        else if (velo > maxSpeed + 5)
        {
            rb.velocity = rb.velocity.normalized;
        }
    }
}
