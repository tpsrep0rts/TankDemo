using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActor : GameActor
{
    public GameObject target;
    public float attackRange;
    public float trackRange;
    public float targetDistance;
    PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject players = GameObject.Find("Players");
        playerManager = players.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        target = playerManager.FindClosestPlayer(gameObject);
        if(target) {
            targetDistance = DistanceTo(target);
        } else {
            targetDistance = 0;
        }
    }
    public override bool IsFiring()
    {
        return target && targetDistance < attackRange;
    }
    public override Vector3 GetTargetLocation()
    {
        if(target && targetDistance < trackRange)
        {
            return target.transform.position;
        }
        return transform.position;
    }
}
