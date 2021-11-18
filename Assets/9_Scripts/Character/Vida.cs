using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private int maxVida = 100;
    private int currentHealth;

    public void Start()
    {
        currentHealth = maxVida;
        //GameManager.instance.GetHealthBar.SetMaxHealth(maxVida);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20);
        }
        //quitar el if y reemplazarlo para el sistema de combate
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameManager.instance.GetHealthBar.SetHealth(currentHealth);
    }

    public int CurrentHealth {get => currentHealth; set => currentHealth = value > 0 ? value : 0;}
    public int MaxHealth => maxVida;
}
