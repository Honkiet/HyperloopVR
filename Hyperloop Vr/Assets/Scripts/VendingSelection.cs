using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingSelection : MonoBehaviour
{
    [SerializeField] VendingMachine correspondingVendingMachine;
    [SerializeField] GameObject itemToDispense;

    public void SendSelectionToVendingMachine()
    {
        correspondingVendingMachine.ProcessSelection(itemToDispense);
    }
}
