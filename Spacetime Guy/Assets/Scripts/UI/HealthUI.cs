using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    private Player player;

    private int maxHearts = 10;
    public int currHearts = 3;
    public int currHealth;
    private int maxHealth;
    private int healthPerHeart;

    public Image[] healthImages;
    public Sprite[] healthSprites;


    void Start()
    {
//        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
//        currHealth = (int) player.getCurrentHealth();
//        maxHealth = (int) player.getMaxHealth();
//        healthPerHeart = maxHealth / maxHearts;
//        currHealth = currHearts * healthPerHeart;
//        maxHealth = maxHearts * healthPerHeart;
//        CheckHealthAmount();
    }

    void CheckHealthAmount()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (currHearts <= i)
            {
                healthImages[i].enabled = false;    // disable the heart image if we already have max hearts.
            } else
            {
                healthImages[i].enabled = true;     // enable the heart image if we currently don't have maximum hearts.
            }
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;
        foreach(Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];        
            }
            else
            {
                i++;
                if(currHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
                if (i >= currHearts)    // exit the loop if you already hit the amount of hearts. Avoids division by zero error.
                {
                    break;
                }
            }
        }
    }

    // Probably don't need this
    public void TakeDamage(int amount)
    {
        currHealth += amount;
        currHealth = Mathf.Clamp(currHealth, 0, currHearts * healthPerHeart);
        UpdateHearts();
    }

    public void AddHeartContainer()
    {
        currHearts += 1;
        currHearts = Mathf.Clamp(currHearts, 0, maxHearts);

        currHealth = currHearts * healthPerHeart;
        // maxHealth = maxHearts * healthPerHeart;

        CheckHealthAmount();

    }
    void UpdateUI()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currHealth = (int) player.getCurrentHealth();
        maxHealth = (int) player.getMaxHealth();
        healthPerHeart = maxHealth / maxHearts;
//        currHealth = currHearts * healthPerHeart;
//        maxHealth = maxHearts * healthPerHeart;
        CheckHealthAmount();
        // currHealth = (int) player.getCurrentHealth();
        // UpdateHearts();
        // healthText.text = "Health: " + target.healthCurrent + " / " + target.healthMax;
    }
}

