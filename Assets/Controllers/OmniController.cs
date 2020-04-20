using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniController : MonoBehaviour
{
    GameActor controller;
    Rigidbody rb;
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
        Vector3 direction = new Vector3();
        if (controller.IsTurningLeft())
        {
            direction.x -= maxMovementSpeed;
        }
        else if (controller.IsTurningRight())
        {
            direction.x += maxMovementSpeed;
        }
        if (controller.IsMovingForward())
        {
            direction.z += maxMovementSpeed;
        }
        else if (controller.IsMovingBackward())
        {
            direction.z -= maxMovementSpeed;
        }
        rb.position += direction * Time.deltaTime;
    }
}
