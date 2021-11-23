using System.Collections;
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
    SpriteRenderer spr;
    [SerializeField]
    Vida health;

    string savePath;
    [SerializeField]
    float safeProbability = 70;

    [SerializeField, Range(0.1f, 10f)]
    float rayDistance = 5f;
    [SerializeField]
    Color rayColor = Color.yellow;
    [SerializeField]
    LayerMask detectionLayer;
    [SerializeField]
    Vector2 lastAxis;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        GameManager.instance.LoadGamplayStuffs();
        if(!MemorySystem.LoadGame("gamedata"))
        {
            MemorySystem.NewGame("gamedata");
        }
        /*if(GameManager.instance.LastSceneName != "Battle")
        {
        }*/
        transform.position = GameManager.instance.CurrentGameData.Position;
    }

    void Update()
    {
        Move();
        if(lastAxis.y < 0)
        {
            if(DownRay)
            {
                spr.sortingLayerName = "PlayerBehind";
            }
        }
        if(lastAxis.y > 0)
        {
            if(UpRay)
            {
                spr.sortingLayerName = "PlayerOver";
            }
        }
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
                lastAxis = new Vector2(Axis.normalized.x, Axis.normalized.y);
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
         GameManager.instance.CurrentGameData.SetPosition(transform.position);
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
                    GameManager.instance.LastSceneName = SceneManager.GetActiveScene().name;
                    MemorySystem.SaveGame(GameManager.instance.CurrentGameData, "gamedata");
                    SceneManager.LoadScene("Battle", LoadSceneMode.Single);
                }
                else
                {
                    Debug.Log("safe");
                }
            }
        }
    }

    bool UpRay => Physics2D.Raycast(transform.position, Vector2.up, rayDistance, detectionLayer);
    bool DownRay => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, detectionLayer);

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        if(lastAxis.y > 0)
        {
            Gizmos.DrawRay(transform.position, Vector2.up * rayDistance);
        }
        if(lastAxis.y < 0)
        {
            Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
        }
    }
}
