using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHyperloop : MonoBehaviour
{
    [SerializeField] GameObject doorToOpen;
    [SerializeField] Vector3 teleportDestination;
    [SerializeField] Vector3 teleportRotation;
    int frameEntered;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            doorToOpen.GetComponent<Animator>().Play("HyperloopDoorOpen");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(frameEntered != Time.frameCount)
        {
            doorToOpen.GetComponent<Animator>().Play("HyperloopDoorOpen");
            GameObject.FindGameObjectWithTag("Player").GetComponent<CustomTeleport>().TeleportPlayer(teleportDestination, teleportRotation, 2f);
        }
    }
}
