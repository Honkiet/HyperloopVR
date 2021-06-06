using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Touchscreen : MonoBehaviour
{
    public UnityEvent functionToCall;
    bool hasPressed;
    int framePressed;

    [SerializeField] bool shouldPlayBeepSound;
    AudioSource audioSource;
    

    private void Start()
    {
        if (shouldPlayBeepSound)
        {
            audioSource = GetComponent<AudioSource>();

            if(audioSource == null)
            {
                Debug.LogError("You selected " + gameObject.name + " to play a beep sound when pressed, but there is no AudioSource present. Make sure to add it!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger") && !hasPressed && framePressed != Time.frameCount)
        {
            framePressed = Time.frameCount;
            functionToCall.Invoke();
            hasPressed = true;

            if (shouldPlayBeepSound)
            {
                audioSource.Play();
            }
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
