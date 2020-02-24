using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] hearts;
    public Image fullHeart;
    public Image emptyHeart;
    protected int currHealth;
    // max health deteremined by number of heart images
    void Start()
    {
        currHealth = hearts.Length;
    }

    void SetHealth(int newHealth)
    {
        if (newHealth > hearts.Length)
            newHealth = hearts.Length; //can't exceed maximum num of hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < newHealth)
                hearts[i] = fullHeart;
            else
                hearts[i] = emptyHeart;
        }
    }
}
