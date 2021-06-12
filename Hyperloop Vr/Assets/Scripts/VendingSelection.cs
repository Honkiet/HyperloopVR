using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingSelection : MonoBehaviour
{
    [SerializeField] VendingMachine correspondingVendingMachine;
    [SerializeField] GameObject itemToDispense;
    [SerializeField] Sprite selectionSprite;

    public void SendSelectionToVendingMachine()
    {
        correspondingVendingMachine.ProcessSelection(itemToDispense);
        transform.parent.GetComponent<Image>().sprite = selectionSprite;
    }
}
