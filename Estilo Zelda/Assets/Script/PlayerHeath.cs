using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHeath : MonoBehaviour
{
    public SpriteRenderer[] heartSprites;
    public Sprite[] heartStages;
    private PlayerStatus playerStatus;

    private void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        HealthUI();
    }

    void Update()
    {
       HealthUI();
    }

    public void HealthUI()
    {
        int currentHealth = Mathf.RoundToInt(playerStatus.Life);
        int maxHealth = Mathf.RoundToInt(playerStatus.LifeMax);

        float healthPerHeart = maxHealth / 3.0f;

        for (int i = 0; i < heartSprites.Length; i++)
        {
            float heartThreshold = healthPerHeart * (i + 1);

            if (currentHealth >= heartThreshold)
            {
                heartSprites[i].sprite = heartStages[0];
            }
            else if (currentHealth >= heartThreshold - (healthPerHeart / 5) * 1)
            {
                heartSprites[i].sprite = heartStages[1];
            }
            else if (currentHealth >= heartThreshold - (healthPerHeart / 5) * 2)
            {
                heartSprites[i].sprite = heartStages[2];
            }
            else if (currentHealth >= heartThreshold - (healthPerHeart / 5) * 3)
            {
                heartSprites[i].sprite = heartStages[3];
            }
            else
            {
                heartSprites[i].sprite = heartStages[4];
            }
        }

      

        if (currentHealth <= 0)
        {
           Die();
        }
    }

   public void TakeDamage(int damage)
    {
        playerStatus.TakeDamage(damage);
        HealthUI();

        
       
    }
     private void  Die()
    {
    
        SceneManager.LoadScene("GameOver");
    }
}