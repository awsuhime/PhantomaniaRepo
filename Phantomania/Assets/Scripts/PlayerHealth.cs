using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool injured;
    public bool gameOver;
    public Image injuredOverlay;
    public float maxInjuredOpacity;
    public float alphaBonus = 0.3f;

    private float fadeStart;
    public float timeToHeal = 50f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            takeDamage();
        }

        if (injured)
        {
            float timePassed = Time.time - fadeStart;
            float timeRatio = timePassed / timeToHeal;
            Debug.Log("timeRatio: " + timeRatio + ", Formula: " + (maxInjuredOpacity - (maxInjuredOpacity * timeRatio)));
            

            injuredOverlay.color = new Color(injuredOverlay.color.r, injuredOverlay.color.g, injuredOverlay.color.b, maxInjuredOpacity - (maxInjuredOpacity * timeRatio) + alphaBonus);
            if (timePassed > timeToHeal)
            {
                injuredOverlay.color = new Color(injuredOverlay.color.r, injuredOverlay.color.g, injuredOverlay.color.b, 0);

                injured = false;
            }
        }
    }
    public void takeDamage()
    {
        if (!injured)
        {
            injured = true;
            injuredOverlay.color = new Color(injuredOverlay.color.r, injuredOverlay.color.g, injuredOverlay.color.b, maxInjuredOpacity + alphaBonus);
            fadeStart = Time.time;
        }
        else
        {
            gameOver = true;
        }
    }
}
