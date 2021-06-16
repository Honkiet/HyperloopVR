using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class announcerInside : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip announcerJingle;
    [SerializeField] AudioClip[] departureLines;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator LoopLines()
    {
        yield return new WaitForSeconds(5f);
        audioSource.clip = announcerJingle;
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        audioSource.clip = departureLines[0];
        audioSource.Play();
        yield return new WaitForSeconds(7f);
        audioSource.clip = departureLines[1];
        audioSource.Play();
        yield return new WaitForSeconds(7f);
        audioSource.clip = departureLines[2];
        audioSource.Play();
        yield return new WaitForSeconds(9f);
        audioSource.clip = departureLines[3];
        audioSource.Play();
        audioSource.loop = enabled;
    }
}
