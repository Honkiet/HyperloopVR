using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Touchscreen : MonoBehaviour
{
    //[SerializeField] MeshRenderer disco;
    //[SerializeField] Color[] colors;
    //int index;
    //bool discoTime;

    public UnityEvent functionToCall;
    public static bool hasPressed;
    bool framePressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger") && !hasPressed)
        {
            functionToCall.Invoke();
            hasPressed = true;
            gameObject.transform.parent.gameObject.SetActive(false);

            //if (!discoTime)
            //{
            //    discoTime = true;
            //    StartCoroutine(Disco());
            //}
            //else
            //{
            //    discoTime = false;
            //}
        }
            

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger") && hasPressed)
        {
            hasPressed = false;
        }
    }

    //IEnumerator Disco()
    //{
    //    while (discoTime)
    //    {
    //        disco.material.color = colors[index];
    //        index++;
    //        if (index > 5)
    //            index = 0;
    //        yield return new WaitForSeconds(0.5f);
    //        yield return null;
    //    }

    //}
}
