using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data", order = 51)]
public class PlayerData : ScriptableObject
{
    public int health;

    [SerializeField]
    private float baseMovementSpeed;
    public float movementSpeed;

    [SerializeField]
    private List<PlayerBuffData> buffData;

    public int Health
    {
        get
        {
            return health;
        }
    }

    public float BaseMovementSpeed
    {
        get
        {
            return BaseMovementSpeed;
        }
    }

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
    }
    public List<PlayerBuffData> Buffs
    {
        get
        {
            return buffData;
        }
        set { }
    }
}
