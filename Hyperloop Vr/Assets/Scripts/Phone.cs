using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Phone : MonoBehaviour
{
    [SerializeField] Transform phoneLocation;
    GameObject player;
    bool spawn;

    [SerializeField] GameObject paymentApp;
    [SerializeField] GameObject ticketApp;
    [SerializeField] GameObject mainMenu;

    public delegate void PhoneScanFunction();
    public event PhoneScanFunction scanFunction;
    int framePressed;

    [SerializeField] CustomTeleport teleporterScript;
    [SerializeField] Vector3 teleportPosition;

    public enum PhoneScanState { none, ticket, payment }
    public PhoneScanState phoneScanState;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = new Vector3(0, -10f, 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //public void SpawnPhone()
    //{
    //    spawn = !spawn;

    //    if (spawn)
    //    {
    //        gameObject.transform.position = phoneLocation.position;
    //        gameObject.transform.LookAt(player.transform);
    //        gameObject.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    //    }
    //    else
    //    {
    //        gameObject.transform.position = new Vector3(0, -100f, 0);
    //    }
        
    //}

    public void SpawnInFrontOfPlayer()
    {
        gameObject.transform.position = phoneLocation.position;
        gameObject.transform.LookAt(player.transform);
        gameObject.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    public void SpawnAtLocation(Vector3 location)
    {
        gameObject.transform.position = location;
        gameObject.transform.LookAt(player.transform);
        gameObject.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Scanner" && framePressed != Time.frameCount && scanFunction != null && phoneScanState == PhoneScanState.payment)
        {
            framePressed = Time.frameCount;
            scanFunction.Invoke();
            StartCoroutine(ResetScanFunction());
        }

        if(other.name == "GateScanner" && framePressed != Time.frameCount && phoneScanState == PhoneScanState.ticket)
        {
            framePressed = Time.frameCount;
            teleporterScript.TeleportPlayer(teleportPosition);
            gameObject.transform.position = new Vector3(0, -100f, 0);
        }
    }

    IEnumerator ResetScanFunction()
    {
        yield return new WaitForEndOfFrame();
        scanFunction = null;
    }

    public void EnableApp(string loadApp)
    {
        Transform canvasTransform = gameObject.transform.GetChild(0);

        for (int i = 0; i < canvasTransform.transform.childCount; i++)
        {
            canvasTransform.GetChild(i).gameObject.SetActive(false);
        }

        if (loadApp.ToLower() == "payment")
        {
            paymentApp.SetActive(true);
            phoneScanState = PhoneScanState.payment;
        }
        else if (loadApp.ToLower() == "ticket")
        {
            ticketApp.SetActive(true);
            phoneScanState = PhoneScanState.ticket;
        }
    }

    public void BackToPhoneMenu()
    {
        Transform canvasTransform = gameObject.transform.GetChild(0);

        for (int i = 0; i < canvasTransform.transform.childCount; i++)
        {
            canvasTransform.GetChild(i).gameObject.SetActive(false);
        }

        mainMenu.SetActive(true);
        phoneScanState = PhoneScanState.none;
    }
}
