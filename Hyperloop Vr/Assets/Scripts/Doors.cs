using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator doorAnimator;
    bool canToggle;
    int openClose;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        canToggle = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canToggle && openClose % 2 == 0)
        {
            ToggleDoor(true);
            canToggle = false;
            openClose++;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && canToggle && openClose % 2 == 1)
        {
            ToggleDoor(false);
            canToggle = false;
            openClose++;
        }
    }

    public void EndAnimation()
    {
        canToggle = true;
    }

    public void ToggleDoor(bool open)
    {
        if (open)
        {
            doorAnimator.Play("DoorAnimationOpen");
        }
        else
        {
            doorAnimator.Play("DoorAnimationClose");
        }
    }
}
