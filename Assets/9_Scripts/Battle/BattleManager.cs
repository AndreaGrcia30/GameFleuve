using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    RiverFight riverFight;
    BattleEnemy battleEnemy;

    public static BattleManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Instantiante(Enemygameobject, position, rotation);

        riverFight = GameObject.FindWithTag("Player").GetComponent<RiverFight>();
        battleEnemy = GameObject.FindWithTag("Enemy").GetComponent<BattleEnemy>();

    }

    public RiverFight GetRiverFight => riverFight;
    public BattleEnemy GetBattleEnemy => battleEnemy;
}
