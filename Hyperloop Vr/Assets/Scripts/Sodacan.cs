using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sodacan : MonoBehaviour
{

    public ParticleSystem waterEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > 0.2)
        {
            if (!waterEffect.isPlaying)
            {
                waterEffect.Play();
            }
            
        }
        else
        {
            
            waterEffect.Stop();
            
        }
    }
}
