using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    RiverFight riverFight;
    BattleEnemy battleEnemy;
    bool RiverTurn;
    bool EnemyTurn;
    [SerializeField]
    GameObject Enemygameobject;

    public static BattleManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemygameobject, transform.position, transform.rotation);
        RiverTurn=true;
        EnemyTurn=false;

        riverFight = GameObject.FindWithTag("Player").GetComponent<RiverFight>();
        battleEnemy = GameObject.FindWithTag("Enemy").GetComponent<BattleEnemy>();

    }

    public void ChangeTurn()
    {
        if(RiverTurn==true){
            RiverTurn=false;
            EnemyTurn=true;
        }
        else {
            RiverTurn=true;
            EnemyTurn=false;
        }
    }

    public RiverFight GetRiverFight => riverFight;
    public BattleEnemy GetBattleEnemy => battleEnemy;
}
