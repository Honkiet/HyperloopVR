using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    bool needToPay;
    GameObject selectedItem;
    Vector3 spawnPlacement;
    AudioSource audioSource;
    AudioSource spawnPlaceAudioSource;
    [SerializeField] AudioClip[] dispenseSounds;

    //Add this to every selection:
    //GameObject.FindGameObjectWithTag("Phone").GetComponent<Phone>().scanFunction += Pay;
    //GameObject.FindGameObjectWithTag("CreditCard").GetComponent<CreditCard>().scanFunction += Pay;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        var spawnPlaceGameObject = transform.Find("SpawnPlace");
        spawnPlacement = spawnPlaceGameObject.transform.position;
        spawnPlaceAudioSource = spawnPlaceGameObject.GetComponent<AudioSource>();
    }


    public void ProcessSelection(GameObject selection)
    {
        if(!needToPay)
        {
            selectedItem = selection;
            GameObject.FindGameObjectWithTag("Phone").GetComponent<Phone>().scanFunction += Pay;
            GameObject.FindGameObjectWithTag("CreditCard").GetComponent<CreditCard>().scanFunction += Pay;
            needToPay = true;
        }
    }

    public void Pay()
    {
        audioSource.Play();
        Instantiate(selectedItem, spawnPlacement, Quaternion.identity);
        spawnPlaceAudioSource.clip = dispenseSounds[Random.Range(0, dispenseSounds.Length)];
        spawnPlaceAudioSource.Play();
        needToPay = false;
    }
}
