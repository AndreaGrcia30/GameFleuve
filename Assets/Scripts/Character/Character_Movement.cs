using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
     Rigidbody2D rb;
    Vector3 movement;

    private float speed = 5.0f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
         if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D key was pressed.");
            this.transform.Translate(speed * Time.deltaTime,0,0);
            anim.SetBool("Derecha", true); 
        } else 
        {
           anim.SetBool("Derecha", false); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A key was pressed.");
            this.transform.Translate(speed * Time.deltaTime * -1,0,0);
            anim.SetBool("Izquierda", true);
        } else 
        {
           anim.SetBool("Izquierda", false); 
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W key was pressed.");
            this.transform.Translate(0,speed * Time.deltaTime,0);
            anim.SetBool("Arriba", true); 
        } else 
        {
           anim.SetBool("Arriba", false); 
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S key was pressed.");
            this.transform.Translate(0,speed * Time.deltaTime * -1,0);
            anim.SetBool("Abajo", true); 
        } else 
        {
           anim.SetBool("Abajo", false); 
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("E key was pressed.");
            this.transform.Translate(0,speed * Time.deltaTime * -1,0);
            anim.SetTrigger("Attack"); 
        }
    }

    private void move()
    {
        rb.velocity = new Vector2(movement.x, movement.y);
    }
}
