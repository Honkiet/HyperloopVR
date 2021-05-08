using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    Animator animator;
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Awake()
    {
        startingPosition = transform.position;
        animator = GetComponent<Animator>();

        if(FindObjectOfType<EnterHyperloop>() != null)
        {
            FindObjectOfType<EnterHyperloop>().startMap += StartMovement;
        }
    }

    public void StartMovement()
    {
        gameObject.SetActive(true);
        animator.Play("MapMovement");
        ShowMap(false);
    }

    public void ShowMap(bool show)
    {
        if (show)
        {
            transform.position = startingPosition;
        }
        else
        {
            transform.position = startingPosition - new Vector3(0, 1000f, 0);
        }
    }
}
