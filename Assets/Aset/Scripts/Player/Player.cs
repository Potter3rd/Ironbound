using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player variables
    public float speed = 10.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, inputY * speed);
    }
}
