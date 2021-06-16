using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHyperloop : MonoBehaviour
{
    [SerializeField] GameObject doorToOpen;
    [SerializeField] Vector3 teleportDestination;
    [SerializeField] Vector3 teleportRotation;
    [SerializeField] GameObject SoundCollection;
    int frameEntered;

    public delegate void StartMapMovement();
    public StartMapMovement startMap;

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(frameEntered != Time.frameCount)
        {
            doorToOpen.GetComponent<Animator>().Play("nyperloopDoorOpen");
            doorToOpen.GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("Player").GetComponent<CustomTeleport>().TeleportPlayer(teleportDestination, teleportRotation, 3.5f);
            StartCoroutine(SwitchSounds());
            startMap.Invoke();
        }
    }

    IEnumerator SwitchSounds()
    {
        yield return new WaitForSeconds(2f);
        SoundCollection.transform.Find("Outside Hyperloop").gameObject.SetActive(false);
        var insideSoundsToStart = SoundCollection.transform.Find("Inside Hyperloop").transform.Find("Play When Entering");

        for (int i = 0; i < insideSoundsToStart.childCount; i++)
        {
            insideSoundsToStart.transform.GetChild(i).GetComponent<AudioSource>().Play();
        }
    }
}
