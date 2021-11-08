using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Character_Movement : MonoBehaviour
{
    bool isTalking = false;
    private float speed = 5.0f;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
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

    Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

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

            /*Property spriteProperty = GameManager.instance.GetGameFoundation.GetStaticProperty(definition, "sprite");
            Debug.Log($"{item.definition.displayName} sprite: {spriteProperty.AsString()}");*/

            //Debug.Log($"Item {item.id} of definition '{item.definition.key}' created");
            /*if(other.CompareTag("sandwich"))
            {
                Property helthProperty = GameManager.instance.GetGameFoundation.GetStaticProperty(definition, "health");
                Debug.Log($"{item.definition.displayName} health: {helthProperty.AsString()}");
            }*/
            Destroy(other.gameObject);
        }
    }
}
