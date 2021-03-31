using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTeleport : MonoBehaviour
{
    //Teleport the player from a script instead of a button press.

    public void TeleportPlayer(Vector3 location)
    {
        transform.position = location;
    }

    public void TeleportPlayer(Vector3 location, float delay)
    {
        StartCoroutine(TeleportAfterDelay(location, delay));
    }

    public void TeleportPlayer(Vector3 location, Vector3 rotationValue)
    {
        transform.position = location;
        transform.rotation = Quaternion.Euler(0, rotationValue.y, 0);
    }

    public void TeleportPlayer(Vector3 location, Vector3 rotationValue, float delay)
    {
        StartCoroutine(TeleportAndRotateAfterDelay(location, rotationValue, delay));
    }

    IEnumerator TeleportAfterDelay(Vector3 location, float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = location;
    }

    IEnumerator TeleportAndRotateAfterDelay(Vector3 location, Vector3 rotationValue, float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = location;
        transform.rotation = Quaternion.Euler(0, rotationValue.y, 0);
    }
}
