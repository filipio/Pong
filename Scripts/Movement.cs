using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ [SerializeField] private float speedMovement = 5f;
    public bool player1;
    private float moveVertical = 0f;
    public Rigidbody2D rb;
    private Vector3 startPosition;
    public Vector3 pointRightCenter;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        startPosition = transform.position;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Move()
    {
        if(player1)
        {
            moveVertical = Input.GetAxisRaw("VerticalPlayerOne");
        }
        else
        {
            moveVertical = Input.GetAxisRaw("VerticalPlayerTwo");
        }

        rb.velocity =new Vector2(rb.velocity.x, moveVertical * speedMovement);


    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    void FixedUpdate()
    {
        Move();
        
    }

}
