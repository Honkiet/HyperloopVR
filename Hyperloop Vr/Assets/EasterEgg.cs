using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EasterEgg : MonoBehaviour
{
    [SerializeField] SpriteRenderer currentRenderer;
    [SerializeField] SpriteRenderer[] differentPictures;
    int pictureIndex;
    float visibilityValue = 0f;
    float visibilityIncrease = 0.05f;
    float startWaitValue = 0f;
    float startWaitLimit = 7f;

    // Start is called before the first frame update
    void Start()
    {
        currentRenderer = differentPictures[0];
        currentRenderer.color = new Color(255, 255, 255, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(startWaitValue < startWaitLimit)
            {
                startWaitValue += Time.deltaTime;
                return;
            }

            if (visibilityValue < 255)
            {
                visibilityValue += visibilityIncrease * Time.deltaTime;
                currentRenderer.color = new Color(255, 255, 255, visibilityValue);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(startWaitValue < startWaitLimit)
        {
            startWaitValue = 0f;
            visibilityValue = 0f;
        }
        else
        {
            currentRenderer.color = new Color(255, 255, 255, 0);

            if(pictureIndex == differentPictures.Length - 1)
            {
                pictureIndex = 0;
                currentRenderer = differentPictures[pictureIndex];
            }
            else
            {
                pictureIndex++;
                currentRenderer = differentPictures[pictureIndex];
            }

            startWaitValue = 0f;
            visibilityValue = 0f;
        }
    }
}
