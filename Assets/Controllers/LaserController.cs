using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public bool isFiring;
    public GameObject laserBeamObject;
    LaserBeamController laserBeam;
    public GameObject emitter;
    // Start is called before the first frame update
    void Start()
    {
        laserBeam = laserBeamObject.GetComponent<LaserBeamController>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Fire(Vector3 end)
    {
        isFiring = true;
        laserBeam.Activate(emitter.transform.position, end);
    }

    public void StopFiring()
    {
        isFiring = false;
        laserBeam.Deactivate();
    }
}
