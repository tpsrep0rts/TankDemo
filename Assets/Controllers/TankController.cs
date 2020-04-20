using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    GameActor controller;
    Rigidbody rb;
    public float maxRotationSpeed;
    public float maxMovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<GameActor>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.IsTurningLeft())
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -maxRotationSpeed, 0) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        } else if(controller.IsTurningRight())
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, maxRotationSpeed, 0) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if(controller.IsMovingForward()) {
           rb.position += transform.forward * Time.deltaTime * maxMovementSpeed;
        } else if(controller.IsMovingBackward()) {
           rb.position -= transform.forward * Time.deltaTime * maxMovementSpeed;
        }
    }
}
