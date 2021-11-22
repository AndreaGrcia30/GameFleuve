using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActor : MonoBehaviour
{
    protected Animator anim;

    protected bool diying = false;
    [SerializeField]
    protected int damage = 10;
    protected bool doingAction = false;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected void ChangeTurn() => BattleManager.instance.ChangeTurn();
}
