using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    RiverFight riverFight;
    BattleEnemy battleEnemy;
    [SerializeField]
    bool isPlayerTurn = true;
    [SerializeField]
    GameObject Enemygameobject;
    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();
    public static BattleManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Enemygameobject = enemies[Random.Range(0, enemies.Count - 1)];
        riverFight = GameObject.FindWithTag("Player").GetComponent<RiverFight>();
        battleEnemy = Instantiate(Enemygameobject, new Vector2(-riverFight.transform.position.x, riverFight.transform.position.y),
        transform.rotation).GetComponent<BattleEnemy>();
        CheckForEnemyTurn();
    }

    public void CheckForEnemyTurn() => StartCoroutine(CheckForEnemyTurnCorutine());

    IEnumerator CheckForEnemyTurnCorutine()
    {
        while (true)
        {
            if(!IsPlayerTurn)
            {
                GetBattleEnemy.Attack();
                break;
            }
            yield return null;
        }
    }

    public RiverFight GetRiverFight => riverFight;
    public BattleEnemy GetBattleEnemy => battleEnemy;
    public bool IsPlayerTurn{get => isPlayerTurn; set => isPlayerTurn = value;}
    public void ChangeTurn() => IsPlayerTurn = !IsPlayerTurn;

}
