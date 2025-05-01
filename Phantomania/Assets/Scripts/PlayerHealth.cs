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
    private GameManager gameManager;

    private float fadeStart;
    public float timeToHeal = 50f;

    private bool invincible;
    private float invStart;
    public float invincibility = 5f;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (Time.time - invStart > invincibility)
        {
            invincible = false;
        }
        

        if (injured)
        {
            float timePassed = Time.time - fadeStart;
            float timeRatio = timePassed / timeToHeal;
            

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
        if (!invincible)
        {
            if (!injured)
            {
                injured = true;
                injuredOverlay.color = new Color(injuredOverlay.color.r, injuredOverlay.color.g, injuredOverlay.color.b, maxInjuredOpacity + alphaBonus);
                fadeStart = Time.time;
                invincible = true;
                invStart = Time.time;
            }
            else
            {
                gameOver = true;
                gameManager.Restart();

            }
        }
        
    }
}
