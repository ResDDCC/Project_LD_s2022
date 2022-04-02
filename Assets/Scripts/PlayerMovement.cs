using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float run_speed;
    public Rigidbody2D rb;
    private Vector2 move_dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Take input
        TakeInputs();
    }

    void FixedUpdate()
    {
        //Calculate movement
        Move();
    }

    void TakeInputs()
    {
        float move_x = Input.GetAxisRaw("Horizontal");
        float move_y = Input.GetAxisRaw("Vertical");

        move_dir = new Vector2(move_x, move_y);
    }

    void Move()
    {
        rb.velocity = new Vector2(move_dir.x * run_speed, move_dir.y * run_speed);
    }


}
