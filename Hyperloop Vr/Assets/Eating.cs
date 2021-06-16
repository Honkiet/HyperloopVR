using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    [SerializeField] AudioClip[] eatingSounds;
    [SerializeField] AudioClip[] drinkingSounds;
    int frameEaten;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food") && frameEaten != Time.frameCount)
        {
            frameEaten = Time.frameCount;
            other.transform.parent = null;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject, 0.5f);
            //other.name = "Eaten Food";
            //GameObject.Find("Eaten Food");
            //Destroy(GameObject.Find("Eaten Food"), 0.1f);
            audioSource.clip = eatingSounds[Random.Range(0, eatingSounds.Length)];
        }
    }
}
