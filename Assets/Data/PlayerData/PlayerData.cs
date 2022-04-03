using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data", order = 51)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int health;

    [SerializeField]
    private float baseMovementSpeed;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private List<PlayerBuffData> buffData;

    public List<PlayerBuffData> Buffs
    {
        get
        {
            return buffData;
        }
        set {}
    }
}
