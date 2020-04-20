using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamController : MonoBehaviour
{
    LineRenderer laserLine;
    public float beamWidth;
    public bool isActive;

    Vector3 startPosition;
    Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.startWidth = beamWidth;
        laserLine.endWidth = beamWidth;
        laserLine.enabled = false;
        isActive = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate(Vector3 sp, Vector3 ep)
    {
        startPosition = sp;
        endPosition = ep;
        laserLine.SetPosition(0, startPosition);
        laserLine.SetPosition(1, endPosition);
        laserLine.enabled = true;
        isActive = true;
    }

    public void Deactivate()
    {
        laserLine.enabled = false;
        isActive = false;
    }
}
