using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip announcerJingle;
    [SerializeField] AudioClip departureLine;
    [SerializeField] AudioClip arrivalLine;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(LoopLines());
    }

    IEnumerator LoopLines()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            audioSource.clip = announcerJingle;
            audioSource.Play();
            yield return new WaitForSeconds(3f);
            audioSource.clip = arrivalLine;
            audioSource.Play();

            yield return new WaitForSeconds(90f);
            audioSource.clip = announcerJingle;
            audioSource.Play();
            yield return new WaitForSeconds(3f);
            audioSource.clip = arrivalLine;
            audioSource.Play();
        }
    }
}
