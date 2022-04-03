using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Data Class describing Arcana Challenge Data
[CreateAssetMenu(fileName = "ArcanaChallengeData", menuName = "Arcana Challenge", order = 51)]
public class ArcanaChallengeData : ScriptableObject
{
    [SerializeField]
    private string arcanaName;
    [SerializeField]
    private string description;
    [SerializeField]
    private float timeProvided;
    [SerializeField]
    private PlayerBuffData playerBuff;
    [SerializeField]
    private string arenaChallengeManagerComponentName;

    #region Getters
    public string ArcanaName
    {
        get
        {
            return arcanaName;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public float TimeProvided
    {
        get
        {
            return timeProvided;
        }
    }

    public PlayerBuffData PlayerBuff
    {
        get
        {
            return playerBuff;
        }
    }

    // For Use with AddComponent<Type>() on Arena GO
    public System.Type ArcanaChallengeArenaManager
    {
        get
        {
            System.Type arenaManager = System.Type.GetType(arenaChallengeManagerComponentName + ",Assembly-CSharp");
            return arenaManager;
        }
    }
    /**
    System.Type arenaManagerComponent = strengthChallenge.ArcanaChallengeArenaManager;
    ArcanaChallengeArenaManager.AddComponent<arenaManagerComponent>
    */
    #endregion
}
