﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemButton;
    private Transform player;
    public GameObject effect;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sandwich()
    {
       Heal(20);
       Instantiate(effect, player.position, Quaternion.identity);
       Destroy(gameObject);
    }
     void Heal(int heal)
    {
        GameObject thePlayer = GameObject.Find("River");
        Vida vida = thePlayer.GetComponent<Vida>();
        vida.vidaActual += heal;
        Debug.Log("vidaActual" + vida.vidaActual);
        vida.healthBar.SetHealth(vida.vidaActual);
    }

}
