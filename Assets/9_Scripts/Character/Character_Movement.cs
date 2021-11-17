﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using System.IO;
using GameLib.MemorySystem;
using UnityEngine.SceneManagement;

public class Character_Movement : MonoBehaviour
{
    bool isTalking = false;
    private float speed = 5.0f;
    private Animator anim;
    [SerializeField]
    Vida health;

    string savePath;
    [SerializeField]
    float safeProbability = 70;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        GameManager.instance.LoadGamplayStuffs();
        MemorySystem.LoadGame("gamedata");
    }

    void Update()
    {
        Move();
    }

    void LateUpdate()
    {
        if(!isTalking)
        {
            anim.SetFloat("magnitude", Axis.magnitude);
            if(IsWalking)
            {
                anim.SetFloat("axisX", Axis.normalized.x);
                anim.SetFloat("axisY", Axis.normalized.y);
            }
            if(Attack)
            {
                anim.SetTrigger("Attack");
            }
        }
    }

    void Move()
    {
        transform.Translate(Axis.normalized * speed * Time.deltaTime);
    }

    Vector2 Axis => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    public bool IsTalking{get => isTalking; set => isTalking = value;}

    public bool Attack => Input.GetButtonDown("Attack");

    bool IsWalking => Axis.normalized.magnitude != 0;

    float RandomReuslt => Random.Range(0, 100);

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            //Item collectedItem = other.GetComponent<Item>();
            InventoryItemDefinition definition = GameManager.instance.GetGameFoundation.GetItem(other.tag);
            InventoryItem item = GameManager.instance.GetGameFoundation.CreateItem(definition);
            //Debug.Log(GameManager.instance.GetGameFoundation.ItemCount);
            GameManager.instance.GetGameFoundation.AddItemToInventory(item);
            GameManager.instance.GetGameFoundation.AddItemDefinitionKeyToInventory(definition.key);

            /*Property spriteProperty = GameManager.instance.GetGameFoundation.GetStaticProperty(definition, "sprite");
            Debug.Log($"{item.definition.displayName} sprite: {spriteProperty.AsString()}");*/

            //Debug.Log($"Item {item.id} of definition '{item.definition.key}' created");
            /*if(other.CompareTag("sandwich"))
            {
                Property helthProperty = GameManager.instance.GetGameFoundation.GetStaticProperty(definition, "health");
                Debug.Log($"{item.definition.displayName} health: {helthProperty.AsString()}");
            }*/
            Destroy(other.gameObject);
            //MemorySystem.SaveGame(new GameData(health.CurrentHealth, 1, GameManager.instance.GetGameFoundation.ItemDefinitionKeys.ToArray()), "gamedata");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("wildarea"))
        {
            if(!isTalking && IsWalking)
            {
                if(RandomReuslt > safeProbability)
                {
                    Debug.Log("combat");
                    SceneManager.LoadScene("Battle", LoadSceneMode.Single);
                }
                else
                {
                    Debug.Log("safe");
                }
            }
        }
    }
}
