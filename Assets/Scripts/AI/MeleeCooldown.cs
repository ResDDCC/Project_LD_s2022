using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCooldown : MonoBehaviour, IHasCooldown
{
    [Header("Settings")]
    [SerializeField] private int id;
    [SerializeField] private float cooldownDuration;

    public int Id => id;
    public float CooldownDuration => cooldownDuration;

    // Start is called before the first frame update
    void Start()
    {
        id = 1;
        cooldownDuration = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
