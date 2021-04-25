using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTablet : MonoBehaviour
{
    [SerializeField] Animator hatchAnimation;
    [SerializeField] Animator screenAnimation;
    bool canToggle;
    int showHide;

    // Start is called before the first frame update
    void Start()
    {
        canToggle = true;
    }

    public void PlayCorrectAnimation()
    {
        if (showHide % 2 == 0 && canToggle)
        {
            StartCoroutine(PlayShowAnimation());
            canToggle = false;
            showHide++;
        }
        else if(showHide % 2 == 1 && canToggle)
        {
            StartCoroutine(PlayHideAnimation());
            canToggle = false;
            showHide++;
        }
    }

    IEnumerator PlayShowAnimation()
    {
        hatchAnimation.Play("TableHatchOpen");
        yield return new WaitForSeconds(0.7f);
        screenAnimation.Play("TableScreenShow");
        yield return new WaitForSeconds(0.7f);
        canToggle = true;
    }

    IEnumerator PlayHideAnimation()
    {
        screenAnimation.Play("TableScreenHide");
        yield return new WaitForSeconds(0.7f);
        hatchAnimation.Play("TableHatchClose");
        yield return new WaitForSeconds(0.7f);
        canToggle = true;
    }
}
