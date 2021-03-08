using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchscreen : MonoBehaviour
{
    [SerializeField] MeshRenderer disco;
    [SerializeField] Color[] colors;
    int index;
    bool discoTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IndexFinger"))
        {
            if (!discoTime)
            {
                discoTime = true;
                StartCoroutine(Disco());
            }
            else
            {
                discoTime = false;
            }
        }
            

    }

    IEnumerator Disco()
    {
        while (discoTime)
        {
            disco.material.color = colors[index];
            index++;
            if (index > 5)
                index = 0;
            yield return new WaitForSeconds(0.5f);
            yield return null;
        }
        
    }
}
