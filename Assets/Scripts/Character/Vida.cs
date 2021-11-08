using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
     HealthBar healthBar;
    private int maxVida = 100;
    private int vidaActual;
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
