using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField]
    int maxVida = 100;
    [SerializeField]
    int currentHealth;

    public void Start()
    {
        currentHealth =  GameManager.instance.CurrentGameData.CurrentPlayerHealth;
        GameManager.instance.GetHealthBar.SetMaxHealth(maxVida);
        GameManager.instance.GetHealthBar.SetHealth(GameManager.instance.CurrentGameData.CurrentPlayerHealth);
    }
    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20);
        }*/
        //quitar el if y reemplazarlo para el sistema de combate
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameManager.instance.GetHealthBar.SetHealth(currentHealth);
        GameManager.instance.UpdateHealthInCurrentData();
        //Debug.Log(GameManager.instance.CurrentGameData.CurrentPlayerHealth);
    }

    public int CurrentHealth {get => currentHealth; set => currentHealth = value > 0 ? value : 0;}
    public int MaxHealth => maxVida;
}
