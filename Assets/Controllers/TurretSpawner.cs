using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public GameObject turretMounts;
    public GameObject turretPrefab;
    public int turretRows;
    public int turretColumns;
    public float turretXInterval;
    public float turretZInterval;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTurrets();
    }

    void SpawnTurrets()
    {
        float turretStartX = turretMounts.transform.position.x - ((turretRows - 1) * turretXInterval) / 2;
        float turretStartZ = turretMounts.transform.position.z - ((turretColumns - 1) * turretZInterval) / 2;

        for (int x = 0; x < turretRows; x++)
        {
            for (int z = 0; z < turretColumns; z++)
            {
                SpawnTurret(new Vector3(
                    turretStartX + x * turretXInterval,
                    turretMounts.transform.position.y,
                    turretStartZ + z * turretZInterval));

            }
        }
    }
    GameObject SpawnTurret(Vector3 position) {
        GameObject turret = Instantiate(turretPrefab, position,Quaternion.identity);
        Vector3 localScale = turret.transform.localScale;
        turret.transform.SetParent(turretMounts.transform);
        turret.transform.localScale = new Vector3(scale * localScale.x, scale * localScale.y, scale * localScale.z);
        return turret;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
