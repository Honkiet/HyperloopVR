using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetWater : MonoBehaviour
{
    // Start is called before the first frame update
    public void ShowWater()
    {
        transform.GetComponent<Renderer>().enabled = true;
    }

    public void StopWater()
    {
        transform.GetComponent<Renderer>().enabled = false;
    }
}
