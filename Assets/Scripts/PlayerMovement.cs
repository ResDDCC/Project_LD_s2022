using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    public float run_speed;
    public Rigidbody2D rb;
    private Vector2 move_dir;
    public int health = 2;
    private bool touchingEnemy = false;
    [Header("Heart Images")]
    public Image[] hearts;
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
        //UI
        UpdateUI();
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

    //UI
    void UpdateUI()
    {
        if(health == 3)
        {
            hearts[0].fillAmount = 1;
            hearts[1].fillAmount = 1;
            hearts[2].fillAmount = 1;
        }else if(health == 2)
        {
            hearts[0].fillAmount = 1;
            hearts[1].fillAmount = 1;
            hearts[2].fillAmount = 0;
        }else if(health == 1)
        {
            hearts[0].fillAmount = 1;
            hearts[1].fillAmount = 0;
            hearts[2].fillAmount = 0;
        } else {
            hearts[0].fillAmount = 0;
            hearts[1].fillAmount = 0;
            hearts[2].fillAmount = 0;
        }
    }

    //Collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if colliding with enemy
        if(collision.gameObject.tag == "Enemy" && touchingEnemy == false)
        {
            health -= 1;
            touchingEnemy = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Check if colliding with enemy
        if(collision.gameObject.tag == "Enemy" && touchingEnemy)
        {
            touchingEnemy = false;
        }
    }
}
