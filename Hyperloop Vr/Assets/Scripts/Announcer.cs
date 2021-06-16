using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip announcerJingle;
    [SerializeField] AudioClip[] arrivalLines;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(LoopLines());
    }

    IEnumerator LoopLines()
    {
        yield return new WaitForSeconds(20f);
        audioSource.clip = announcerJingle;
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        audioSource.clip = arrivalLines[0];
        audioSource.Play();
        yield return new WaitForSeconds(11f);
        audioSource.clip = arrivalLines[1];
        audioSource.Play();
        yield return new WaitForSeconds(10f);
        audioSource.clip = arrivalLines[2];
        audioSource.Play();
    }
}
