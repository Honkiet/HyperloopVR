using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCard : MonoBehaviour
{
    int framePressed;
    AudioSource audioSource;
    [SerializeField] GameObject player;
    [SerializeField] Transform creditCardLocation;

    public delegate void PhoneScanFunction();
    public event PhoneScanFunction scanFunction;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SpawnInFrontOfPlayer()
    {
        gameObject.transform.position = creditCardLocation.position;
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
        if (other.name == "Scanner" && framePressed != Time.frameCount && scanFunction != null)
        {
            framePressed = Time.frameCount;
            audioSource.Play();
            StartCoroutine(ResetScanFunction());
        }
    }

    IEnumerator ResetScanFunction()
    {
        yield return new WaitForEndOfFrame();
        scanFunction = null;
    }
}
