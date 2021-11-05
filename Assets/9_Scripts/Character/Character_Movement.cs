using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
