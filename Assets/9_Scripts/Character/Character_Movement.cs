using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using System.IO;
using GameLib.MemorySystem;

public class Character_Movement : MonoBehaviour
{
    bool isTalking = false;
    private float speed = 5.0f;
    private Animator anim;
    [SerializeField]
    Vida health;

    string savePath;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //MemorySystem.NewGame("juegoperron");
        //MemorySystem.LoadGame("gamedata");
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
            if(Axis.normalized.magnitude != 0)
            {
                anim.SetFloat("axisX", Axis.normalized.x);
                anim.SetFloat("axisY", Axis.normalized.y);
            }
        }
    }

    void Move()
    {
        transform.Translate(Axis.normalized * speed * Time.deltaTime);
    }

    Vector2 Axis => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    public bool IsTalking{get => isTalking; set => isTalking = value;}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("item collected");
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
}
