using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (FindObjectOfType<EnterHyperloop>() != null)
        {
            FindObjectOfType<EnterHyperloop>().startMap += StartMovement;
        }
    }

    public void StartMovement()
    {
        animator.Play("LineOnGround");
    }
}
