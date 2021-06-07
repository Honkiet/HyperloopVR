using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSpawn : MonoBehaviour
{
    [SerializeField] GameObject phone;
    [SerializeField] GameObject creditCard;
    [Header("Leave empty to spawn in front of player")]
    [SerializeField] Vector3 spawnLocationPhone;
    [SerializeField] Vector3 spawnLocationCreditCard;

    public void SpawnPhone()
    {
        if (spawnLocationPhone == null || spawnLocationPhone == Vector3.zero)
        {
            phone.GetComponent<Phone>().SpawnInFrontOfPlayer();
        }
        else
        {
            phone.GetComponent<Phone>().SpawnAtLocation(spawnLocationPhone);
        }
    }   

    public void SpawnCreditCard()
    {
        if (spawnLocationCreditCard == null || spawnLocationCreditCard == Vector3.zero)
        {
            GameObject.FindGameObjectWithTag("CreditCard").GetComponent<CreditCard>().SpawnInFrontOfPlayer();
        }
        else
        {
            GameObject.FindGameObjectWithTag("CreditCard").GetComponent<CreditCard>().SpawnAtLocation(spawnLocationCreditCard);
        }
    }
}
