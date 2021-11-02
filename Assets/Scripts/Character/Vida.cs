using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxVida = 100;
    public int vidaActual;
    public void Start()
    {
        vidaActual = maxVida;
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
        vidaActual -= damage;
        healthBar.SetHealth(vidaActual);
    }


    

}
