using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Data")]
    private PlayerData playerData;

    [Header("Movement Variables")]
    public float movementSpeed;
    private Vector2 moveDirection;

    [Header("Collision Variables")]
    public Rigidbody2D rb;
    private bool touchingEnemy = false;
    private int collisions = 0;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerData = ProgressionStore.Instance.HandleNewPlayer(gameObject);
    }
    #region Combat
    void OnAttack(InputValue value)
    {

    }
    #endregion

    #region Movement

    void FixedUpdate()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void Move()
    {
        //rb.velocity = new Vector2(move_dir.x * run_speed, move_dir.y * run_speed);
        Vector2 currentPos = rb.position;
        Vector2 adjustedMovement = moveDirection * movementSpeed;
        Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    #endregion

    #region Collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if colliding with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            collisions++;
            touchingEnemy = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Check if colliding with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            collisions--;
            if (collisions <= 0)
            {
                collisions = 0;
                touchingEnemy = false;
            }
        }
    }
    #endregion


}
