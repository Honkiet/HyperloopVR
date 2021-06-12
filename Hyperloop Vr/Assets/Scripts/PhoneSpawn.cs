using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSpawn : MonoBehaviour
{
    [SerializeField] GameObject phone;
    [SerializeField] GameObject creditCard;
    [Header("Leave empty to spawn in front of player")]
    [SerializeField] Transform spawnLocationPhone;
    [SerializeField] Transform spawnLocationCreditCard;

    public void SpawnPhone()
    {
        if (spawnLocationPhone == null)
        {
            phone.GetComponent<Phone>().SpawnInFrontOfPlayer();
        }
        else
        {
            phone.GetComponent<Phone>().SpawnAtLocation(spawnLocationPhone.position);
        }
    }   

    public void SpawnCreditCard()
    {
        if (spawnLocationCreditCard == null)
        {
            GameObject.FindGameObjectWithTag("CreditCard").GetComponent<CreditCard>().SpawnInFrontOfPlayer();
        }
        else
        {
            GameObject.FindGameObjectWithTag("CreditCard").GetComponent<CreditCard>().SpawnAtLocation(spawnLocationCreditCard.position);
        }
    }
}
