using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Health : MonoBehaviour
{
    [SerializeReference]
    private float health = 0f;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject healthbarUI;

    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = health;
    }

    public void UpdateHealth(float mod)
    {
        health -= mod;
        slider.value = CalculateHealth();

        if (health > maxHealth)
        {
            health = maxHealth;

        }
        else if (health <= 0)
        {
            health = 0f;

            if (isPlayer)
            {
                //gameOver.DetermineGameOver();
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }
}
