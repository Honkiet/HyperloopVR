﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Phone : MonoBehaviour
{
    [SerializeField] Transform phoneLocation;
    GameObject player;
    bool spawn;

    [SerializeField] GameObject firstApp;
    [SerializeField] GameObject secondApp;

    public delegate void PhoneScanFunction();
    public event PhoneScanFunction scanFunction;
    int framePressed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(0, -10f, 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SpawnPhone()
    {
        spawn = !spawn;

        if (spawn)
        {
            gameObject.transform.position = phoneLocation.position;
            gameObject.transform.LookAt(player.transform);
            gameObject.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(0, -100f, 0);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Scanner" && framePressed != Time.frameCount && scanFunction != null)
        {
            framePressed = Time.frameCount;
            scanFunction.Invoke();
            StartCoroutine(ResetScanFunction());
        }
    }

    IEnumerator ResetScanFunction()
    {
        yield return new WaitForEndOfFrame();
        scanFunction = null;
    }

    public void EnableFirstApp()
    {
        firstApp.SetActive(true);
    }

    public void EnableSecondApp()
    {
        secondApp.SetActive(true);
    }
}
