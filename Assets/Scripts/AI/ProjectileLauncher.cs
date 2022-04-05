using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour, IHasCooldown
{
    [Header("References")]
    [SerializeField] private CooldownManager cooldownManager;
    [SerializeField] private GameObject projectile;


    [Header("Settings")]
    [SerializeField] private int id;
    [SerializeField] private float cooldownTime;

    public int Id => id;
    public float CooldownDuration => cooldownTime;
    private bool firing;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldownManager = GameObject.FindGameObjectWithTag("CooldownManager").GetComponent<CooldownManager>();
        firing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownManager.IsOnCooldown(id) || !firing) { return; }
        
        GameObject bullet = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        cooldownManager.PutOnCooldown(this);
    }

    public void Fire(bool on) {
        firing = on;
    }
}
