using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSpawn : MonoBehaviour
{
    [SerializeField] GameObject phone;
    [Header("Leave empty to spawn in front of player")]
    [SerializeField] Vector3 spawnLocation;

    public void SpawnPhone()
    {
        if (spawnLocation == null || spawnLocation == Vector3.zero)
        {
            phone.GetComponent<Phone>().SpawnInFrontOfPlayer();
        }
        else
        {
            phone.GetComponent<Phone>().SpawnAtLocation(spawnLocation);
        }
    }   
}
