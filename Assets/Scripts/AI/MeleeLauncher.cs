using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeLauncher : MonoBehaviour, IHasCooldown, IHasChargeTime
{
    [Header("References")]
    [SerializeField] private CooldownManager cooldownManager;
    [SerializeField] private ChargeManager chargeManager;
    
    
    [Header("Settings")]
    [SerializeField] private int id;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private float chargeDuration;
    [SerializeField] private float forceMag = 1f;
    private Rigidbody2D rb;

    public int CoolId => id;
    public float CooldownDuration => cooldownDuration;

    public int chargeId => id;
    public float ChargeDuration => chargeDuration;

    private bool charged;
    public bool attacking;
    private bool pushed;


    //bool ready;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        id = 3;
        cooldownDuration = 2f;
        chargeDuration = 0.5f;
        cooldownManager = GameObject.FindGameObjectWithTag("CooldownManager").GetComponent<CooldownManager>();
        chargeManager = GameObject.FindGameObjectWithTag("ChargeManager").GetComponent<ChargeManager>();
        charged = false;
        attacking = false;
        pushed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (!attacking || cooldownManager.IsOnCooldown(id) || chargeManager.IsCharging(id)) { return; }

        // if (!charged) 
        // { 
        //     chargeManager.SetCharge(this); 
        //     charged = true;
        //     return; 
        // }

        // Debug.Log("pushed: " + pushed.ToString());

        // if (!pushed)
        // {
        //     //transform.up.Normalize();
        //     rb.AddForce(transform.up * forceMag, ForceMode2D.Impulse);
        //     pushed = true;
        //     charged = false;
        //     cooldownManager.PutOnCooldown(this);
        // }

        // attacking = false;

        // //if (WaitForCooldown()) { rb.velocity = Vector2.zero; rb.angularVelocity = 0f;}
        // Debug.Log(WaitForCooldown().ToString());

        if (cooldownManager.IsOnCooldown(id)) { return; }
        attacking = false;
    }

    public void Attack(bool on) 
    { 
        //ready = false; 
        cooldownManager.PutOnCooldown(this);
        pushed = false; 
        attacking = on; 
    }

    public bool WaitForCooldown()
    {
        return !attacking;
    }

    // public bool PseudoCooldown()
    // {
    //     return ready;
    // }
}
