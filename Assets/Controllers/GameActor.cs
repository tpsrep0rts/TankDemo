using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual bool IsTurningLeft()
    {
        return false;
    }
    public virtual bool IsTurningRight()
    {
        return false;
    }
    public virtual bool IsMovingForward()
    {
        return false;
    }
    public virtual bool IsMovingBackward()
    {
        return false;
    }
    public virtual bool IsFiring()
    {
        return false;
    }
    public virtual Vector3 GetTargetLocation()
    {
        return new Vector3();
    }

    public float DistanceTo(GameObject target)
    {
        return (target.transform.position - transform.position).magnitude;
    }
    
}
