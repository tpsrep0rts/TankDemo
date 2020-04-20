using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FindClosestPlayer(GameObject source) {
        GameObject target = null;
        float targetDistance = 0;
        foreach(Transform child in transform) {
            float distance = (source.transform.position - child.position).magnitude;
            if (target == null || distance < targetDistance) {
                target = child.gameObject;
                targetDistance = distance;
            }
        }
        return target;
    }
}
