using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    Animator animator;
    Animator parentAnimator;
    Vector3 startingPosition;
    Transform parentPosition;

    // Start is called before the first frame update
    void Awake()
    {
        parentPosition = transform.parent;
        startingPosition = parentPosition.position;
        animator = GetComponent<Animator>();
        parentAnimator = parentPosition.GetComponent<Animator>();
        
        if(FindObjectOfType<EnterHyperloop>() != null)
        {
            FindObjectOfType<EnterHyperloop>().startMap += StartMovement;
        }
    }

    public void StartMovement()
    {
        animator.Play("MapMovement");
        ShowMap(false);
    }

    public void ShowMap(bool show)
    {
        if (show)
        {
            //parentPosition.position = startingPosition;
            parentAnimator.Play("Quickfix Back");
        }
        else
        {
            parentAnimator.Play("Quickfix");
            //parentPosition.GetComponent<RectTransform>().position = startingPosition - new Vector3(0, 1000f, 0);
        }
    }
}
