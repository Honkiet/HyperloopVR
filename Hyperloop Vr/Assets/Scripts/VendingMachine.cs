using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    bool needToPay;
    [SerializeField] GameObject[] items;
    GameObject selectedItem;
    [SerializeField] Vector3 spawnPlacement;

    //Add this to every selection:
    //GameObject.FindGameObjectWithTag("Phone").GetComponent<Phone>().scanFunction += Pay;

    public void SelectionOne()
    {
        if (!needToPay)
        {
            selectedItem = items[0];
            GameObject.FindGameObjectWithTag("Phone").GetComponent<Phone>().scanFunction += Pay;
            needToPay = true;
        }
    }

    public void Pay()
    {
        Instantiate(selectedItem, spawnPlacement, Quaternion.identity);

        needToPay = false;
    }
}
