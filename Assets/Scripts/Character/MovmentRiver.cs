using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentRiver : MonoBehaviour
{
    [SerializeField]  private float speed = 3f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
    }
    // se llama de intervalos fijos y va mejor con las físicas, por eso estoy usando este y no el void Update
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
