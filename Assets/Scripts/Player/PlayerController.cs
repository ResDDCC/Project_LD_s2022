using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Data")]
    private PlayerData playerData;
    private List<PlayerBuff> activePlayerBuffs = new List<PlayerBuff>();

    [Header("Movement Variables")]
    public float movementSpeed;
    [SerializeField]
    Descriptors.PlayerState playerState = Descriptors.PlayerState.Moving;
    private Vector2 moveDirection;
    private Vector2 aimDirection;
    [SerializeField]
    private GameObject centerPointGO;
    [SerializeField]
    private GameObject attackDirectionGO;

    [Header("Collision Variables")]
    public Rigidbody2D rb;
    private bool touchingEnemy = false;
    private int collisions = 0;
    [SerializeField] private LayerMask enemyLayers;

    [Header("Input Settings")]
    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerData = ProgressionStore.Instance.HandleNewPlayer(gameObject);
        playerState = Descriptors.PlayerState.Moving;
    }

    private void Update()
    {
        Vector3 centerPointPosition = centerPointGO.transform.position;
        attackDirectionGO.transform.position = new Vector3(centerPointPosition.x + aimDirection.x * .5f, centerPointPosition.y + aimDirection.y * .5f, centerPointPosition.z);
    }

    void FixedUpdate()
    {
        if (playerState == Descriptors.PlayerState.Moving)
        {
            Move();
        }
    }

    private void ChangeState(Descriptors.PlayerState newState)
    {
        switch (newState) {
            case Descriptors.PlayerState.Frozen:
                playerState = Descriptors.PlayerState.Frozen;
                break;
            case Descriptors.PlayerState.Moving:
                playerState = Descriptors.PlayerState.Moving;
                break;
            case Descriptors.PlayerState.Attacking:
                playerState = Descriptors.PlayerState.Attacking;
                break;
        }
    }

    public void RegisterBuffs()
    {
        foreach (PlayerBuffData buffData in playerData.Buffs)
        {
            RegisterBuff(buffData);
        }
    }

    private void RegisterBuff(PlayerBuffData buffData)
    {
        System.Type playerBuffType = buffData.PlayerBuffComponentType;
        PlayerBuff newComponent = (PlayerBuff) gameObject.AddComponent(playerBuffType);
        activePlayerBuffs.Add(newComponent);
    }

    public void ClearBuffs()
    {
        foreach (PlayerBuff buff in activePlayerBuffs)
        {
            Destroy(buff);
        }
    }

    #region Combat
    void OnAttack(InputValue value)
    {
        //ChangeState(Descriptors.PlayerState.Attacking);

        // play attack animation 
        
        // check for enemies within range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackDirectionGO.transform.position, playerData.AttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) 
        {
            Debug.Log("player hit: " + enemy.name);
        }

        // deal damage
    }
    #endregion

    #region Movement

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void OnAim(InputValue value)
    {
        aimDirection = value.Get<Vector2>();
    }

    void OnAimPos(InputValue value)
    {
        Vector2 pointerPos = value.Get<Vector2>();
        Debug.Log(pointerPos.ToString());
        Vector2 cenPosWorld = centerPointGO.transform.position;
        Vector3 cenPosScreen = Camera.main.WorldToScreenPoint(cenPosWorld);
        aimDirection = new Vector2(pointerPos.x - cenPosScreen.x, pointerPos.y - cenPosScreen.y).normalized;
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
            playerData.health -= 1;
        }
        if(collision.gameObject.tag == "Projectile")
        {
            playerData.health -= 2;
        }
        if (collision.gameObject.tag == "Beam")
        {
            playerData.health -= 5;
        }

        if (playerData.Health <= 0) { Die(); }
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

    void Die()
    {
        Debug.Log("Player died");
        gameObject.SetActive(false);
    }
    
    void OnDrawGizmosSelected()
    {
        if (attackDirectionGO == null) { return; }
        Gizmos.DrawWireSphere(attackDirectionGO.transform.position, playerData.AttackRange);
    }
}
