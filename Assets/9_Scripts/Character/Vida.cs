using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField]
    HealthBar healthBar;
    private int maxVida = 100;
    private int currentHealth;
    public void Start()
    {
        currentHealth = maxVida;
        healthBar.SetMaxHealth(maxVida);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20);
        }
        //quitar el if y reemplazarlo para el sistema de combate
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public int CurrentHealth {get => currentHealth; set => currentHealth = value > 0 ? value : 0;}
    public HealthBar HealthBar => healthBar;
}
