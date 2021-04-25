using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatButton : MonoBehaviour
{
    [SerializeField] GameObject hyperSeat;
    int framePressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger") && framePressed != Time.frameCount)
        {
            framePressed = Time.frameCount;
            hyperSeat.GetComponent<Animator>().SetTrigger("down");
        }
    }
}
