using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPhone : MonoBehaviour
{
    [SerializeField] GameObject phone;

    private void OnTriggerEnter(Collider other)
    {
        phone.GetComponent<Phone>().SpawnInFrontOfPlayer();
        Destroy(gameObject);
    }
}
