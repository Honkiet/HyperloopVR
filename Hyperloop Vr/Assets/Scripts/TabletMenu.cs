using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletMenu : MonoBehaviour
{
    [SerializeField] GameObject[] menuScreens;
    [SerializeField] Sprite[] languageMenuSprites;
    [SerializeField] GameObject[] menuItems;

    [SerializeField] Animator screenAnimator;
    //int appMenuState;
    enum FrontApp { entertainment, travel, placeHolder };
    FrontApp appInFront = FrontApp.entertainment;

    GameObject currentScreen;
    int framePressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AppMenuMove("left");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            AppMenuMove("right");
        }
    }

    public void UpdateLanguageMenu(string language)
    {
        if(Time.frameCount != framePressed)
        {
            if (language.ToLower() == "english")
            {
                transform.Find("Language Menu").transform.GetChild(0).GetComponent<Image>().sprite = languageMenuSprites[0];
                StartCoroutine(WaitToTransition());
            }
            else if (language.ToLower() == "nederlands")
            {
                transform.Find("Language Menu").transform.GetChild(0).GetComponent<Image>().sprite = languageMenuSprites[1];
                StartCoroutine(WaitToTransition());
            }
            else if (language.ToLower() == "deutsch")
            {
                transform.Find("Language Menu").transform.GetChild(0).GetComponent<Image>().sprite = languageMenuSprites[2];
                StartCoroutine(WaitToTransition());
            }
        }

        framePressed = Time.frameCount;
    }

    public void AppMenuMove(string direction)
    {
        if(Time.frameCount != framePressed)
        {
            if (direction.ToLower() == "left")
            {
                if (appInFront == FrontApp.entertainment)
                {
                    screenAnimator.Play("AppMenu1");
                    appInFront = FrontApp.travel;
                    menuItems[0].GetComponent<Collider>().enabled = false;
                    menuItems[2].GetComponent<Collider>().enabled = false;
                    StartCoroutine(DelayedTriggerEnable(menuItems[1].GetComponent<Collider>())); //Travel
                }
                else if (appInFront == FrontApp.travel)
                {
                    screenAnimator.Play("AppMenu2");
                    appInFront = FrontApp.placeHolder;
                    menuItems[0].GetComponent<Collider>().enabled = false;
                    menuItems[1].GetComponent<Collider>().enabled = false;
                    StartCoroutine(DelayedTriggerEnable(menuItems[2].GetComponent<Collider>())); //PlaceHolder
                }
                else if (appInFront == FrontApp.placeHolder)
                {
                    screenAnimator.Play("AppMenu3");
                    appInFront = FrontApp.entertainment;
                    menuItems[1].GetComponent<Collider>().enabled = false;
                    menuItems[2].GetComponent<Collider>().enabled = false;
                    StartCoroutine(DelayedTriggerEnable(menuItems[0].GetComponent<Collider>())); //Entertainment
                }
            }
            else
            {
                if (appInFront == FrontApp.entertainment)
                {
                    screenAnimator.Play("AppMenu6");
                    appInFront = FrontApp.placeHolder;
                    menuItems[0].GetComponent<Collider>().enabled = false;
                    menuItems[1].GetComponent<Collider>().enabled = false;
                    StartCoroutine(DelayedTriggerEnable(menuItems[2].GetComponent<Collider>())); //PlaceHolder
                }
                else if (appInFront == FrontApp.travel)
                {
                    screenAnimator.Play("AppMenu4");
                    appInFront = FrontApp.entertainment;
                    menuItems[1].GetComponent<Collider>().enabled = false;
                    menuItems[2].GetComponent<Collider>().enabled = false;
                    StartCoroutine(DelayedTriggerEnable(menuItems[0].GetComponent<Collider>())); //Entertainment
                }
                else if (appInFront == FrontApp.placeHolder)
                {
                    screenAnimator.Play("AppMenu5");
                    appInFront = FrontApp.travel;
                    menuItems[0].GetComponent<Collider>().enabled = false;
                    menuItems[2].GetComponent<Collider>().enabled = false;
                    StartCoroutine(DelayedTriggerEnable(menuItems[1].GetComponent<Collider>())); //Travel
                }
            }

            IEnumerator DelayedTriggerEnable(Collider colliderToEnable)
            {
                yield return new WaitForSeconds(1f);
                colliderToEnable.enabled = true;
            }

            framePressed = Time.frameCount;
        }
        


        //if (direction.ToLower() == "left")
        //{
        //    appMenuState--;
        //    if (appMenuState < 0) { appMenuState = 2; }

        //    if (appMenuState % 3 == 0)
        //    {
        //        screenAnimator.Play("AppMenu3");
        //        menuItems[0].GetComponent<Collider>().enabled = true; //Entertainment
        //        menuItems[1].GetComponent<Collider>().enabled = false;
        //        menuItems[2].GetComponent<Collider>().enabled = false;

        //    }
        //    else if (appMenuState % 3 == 1)
        //    {
        //        screenAnimator.Play("AppMenu1");
        //        menuItems[2].GetComponent<Collider>().enabled = true; //Travel 2
        //        menuItems[0].GetComponent<Collider>().enabled = false;
        //        menuItems[1].GetComponent<Collider>().enabled = false;
        //    }
        //    else
        //    {
        //        screenAnimator.Play("AppMenu2");
        //        menuItems[1].GetComponent<Collider>().enabled = true; //Travel
        //        menuItems[0].GetComponent<Collider>().enabled = false;
        //        menuItems[2].GetComponent<Collider>().enabled = false;
        //    }
        //}
        //else
        //{
        //    appMenuState++;
        //    if (appMenuState > 2) { appMenuState = 0; }

        //    if (appMenuState % 3 == 0)
        //    {
        //        screenAnimator.Play("AppMenu4");

        //    }
        //    else if (appMenuState % 3 == 1)
        //    {
        //        screenAnimator.Play("AppMenu5");

        //    }
        //    else
        //    {
        //        screenAnimator.Play("AppMenu6");
        //    }
        //}


    }

    public void OpenApp()
    {
        if(appInFront == FrontApp.entertainment)
        {
            menuScreens[3].SetActive(true); //Entertainment
            menuScreens[1].SetActive(false);
            currentScreen = menuScreens[3];
        }
        else if(appInFront == FrontApp.entertainment)
        {
            menuScreens[2].SetActive(true); //Map
            menuScreens[1].SetActive(false);
            currentScreen = menuScreens[2];
        }
        else
        {
            menuScreens[2].GetComponent<MapMovement>().ShowMap(true); //Map
            menuScreens[1].SetActive(false);
            currentScreen = menuScreens[2];
        }

        //if (appMenuState % 3 == 0)
        //{
        //    menuScreens[3].SetActive(true); //Entertainment
        //    menuScreens[1].SetActive(false);
        //    currentScreen = menuScreens[3];
        //}
        //else if (appMenuState % 3 == 1)
        //{
        //    menuScreens[2].SetActive(true); //Map
        //    menuScreens[1].SetActive(false);
        //    currentScreen = menuScreens[2];
        //}
        //else
        //{
        //    menuScreens[2].SetActive(true); //Map
        //    menuScreens[1].SetActive(false);
        //    currentScreen = menuScreens[2];
        //}
    }

    public void BackToAppMenu()
    {
        if(currentScreen == menuScreens[2])
        {
            menuScreens[2].GetComponent<MapMovement>().ShowMap(false);
        }
        else
        {
            currentScreen.SetActive(false);
        }

        menuScreens[1].SetActive(true);
        currentScreen = menuScreens[1];
    }

    IEnumerator WaitToTransition()
    {
        yield return new WaitForSeconds(0.5f);
        menuScreens[0].SetActive(false);
        menuScreens[1].SetActive(true);

        menuItems[0].GetComponent<Collider>().enabled = true; //Entertainment
        menuItems[1].GetComponent<Collider>().enabled = false;
        menuItems[2].GetComponent<Collider>().enabled = false;

        currentScreen = menuScreens[1];
    }
}
