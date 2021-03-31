using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Touchscreen : MonoBehaviour
{
    public UnityEvent functionToCall;
    bool hasPressed;
    int framePressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger") && !hasPressed && framePressed != Time.frameCount)
        {
            framePressed = Time.frameCount;
            functionToCall.Invoke();
            hasPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger") && hasPressed && framePressed != Time.frameCount)
        {
            framePressed = Time.frameCount;
            hasPressed = false;
        }
    }
}
