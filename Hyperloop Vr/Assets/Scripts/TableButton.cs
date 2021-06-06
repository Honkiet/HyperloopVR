using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableButton : MonoBehaviour
{
    [SerializeField] TableTablet correspondingSpot;
    int framePressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger") && framePressed != Time.frameCount)
        {
            framePressed = Time.frameCount;
            correspondingSpot.PlayCorrectAnimation();
        }
    }
}
