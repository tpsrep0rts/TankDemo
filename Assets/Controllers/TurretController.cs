using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;


public class TurretController : MonoBehaviour
{
    public GameObject gun;
    public GameActor controller;
    LaserController laser;

    // Start is called before the first frame update
    void Start()
    {
        laser = gun.GetComponent<LaserController>();
        controller = GetComponent<GameActor>();
}

    // Update is called once per frame
    void Update()
    {
        if (controller)
        {
            Vector3 targetPosition = controller.GetTargetLocation();
            transform.eulerAngles = new Vector3(
                0,
                180 + (float)(Math.Atan2(targetPosition.x - transform.position.x, targetPosition.z - transform.position.z) * 180 / Math.PI),
                0);

            if (controller.IsFiring())
            {
                laser.Fire(targetPosition);
            } else
            {
                laser.StopFiring();
            }
        }
    }
}
