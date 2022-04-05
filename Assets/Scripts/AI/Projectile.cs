using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IHasCooldown
{
    
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int id;
    [SerializeField] private float cooldownTime;

    public int CoolId => id;
    public float CooldownDuration => cooldownTime;

    // Start is called before the first frame update
    void Start()
    {
        id = 1;
        cooldownTime = 5f;
        rb = GetComponent<Rigidbody2D>();
        speed = 4f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = new Vector3(rb.position.x, rb.position.y, 0);
        rb.MovePosition(pos + (transform.up * speed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //deal damage to player
        }
        else {
            // trigger particle effects
            Destroy(this.gameObject);
        }
    }
}
