using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            other.transform.parent = null;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject, 1f);
        }
    }
}
