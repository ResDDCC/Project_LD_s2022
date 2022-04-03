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
    private string challengeTitle;
    [SerializeField]
    private string description;
    [SerializeField]
    private float timeProvided;
    [SerializeField]
    private PlayerBuffData playerBuff;
    [SerializeField]
    private GameObject arcanaChallengeManager;
    [SerializeField]
    private string arcanaChallengeManagerComponentName;
    [SerializeField]
    private GameObject tarotCardPrefab;

    #region Getters
    public string ArcanaName
    {
        get
        {
            return arcanaName;
        }
    }

    public string ChallengeTitle
    {
        get
        {
            return challengeTitle;
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

    public GameObject TarotCardPrefab
    {
        get
        {
            return tarotCardPrefab;
        }
    }

    // For Use with AddComponent<Type>() on Arena GO
    public System.Type ArcanaChallengeManagerType
    {
        get
        {
            System.Type arenaManager = System.Type.GetType(arcanaChallengeManagerComponentName + ",Assembly-CSharp");
            return arenaManager;
        }
    }
    /**
    System.Type arenaManagerComponentType = strengthChallenge.ArcanaChallengeArenaManager;
    Arena.AddComponent(arenaManagerComponentType);
    */
    #endregion
}
