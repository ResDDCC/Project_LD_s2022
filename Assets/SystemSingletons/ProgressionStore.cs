using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton
public class ProgressionStore: MonoBehaviour
{
    public static ProgressionStore Instance { get; private set; }

    // Arcana Challenges Data for Init
    [SerializeField]
    private List<ArcanaChallengeData> arcanaChallengeDataObjects;

    // Runtime Data Logging
    [SerializeField]
    public Dictionary<string, ArcanaChallengeData> completedArcana = new Dictionary<string, ArcanaChallengeData>();
    [SerializeField]
    public Dictionary<string, ArcanaChallengeData> failedArcana = new Dictionary<string, ArcanaChallengeData>();
    [SerializeField]
    public Dictionary<string, ArcanaChallengeData> allArcana = new Dictionary<string, ArcanaChallengeData>();

    // Runtime Player Data & Controllers
    [SerializeField]
    public List<PlayerData> playersData = new List<PlayerData>();
    public List<GameObject> activePlayers = new List<GameObject>();

    // Timer Data
    public float currentTimeRemaining = 0.0f;

    private void Awake()
    {
        // Ensure the Original ProgressionStore is the only one
        if (Instance != null & Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        for (int i = 0; i < arcanaChallengeDataObjects.Count; i++)
        {
            allArcana.Add(arcanaChallengeDataObjects[i].ArcanaName, arcanaChallengeDataObjects[i]);
        }
    }

    #region Player Handling
    public PlayerData HandleNewPlayer(GameObject newPlayer)
    {
        PlayerData newPlayerData;
        if (activePlayers.Count + 1 > playersData.Count)
        {
            newPlayerData = ScriptableObject.CreateInstance<PlayerData>();
            playersData.Add(newPlayerData);
        }
        else
        {
            newPlayerData = playersData[activePlayers.Count];
        }
        activePlayers.Add(newPlayer);
        return newPlayerData;
    }

    public void RemovePlayer(GameObject player)
    {
        activePlayers.Remove(player);
        Destroy(player);
    }
    #endregion

    #region Challenge & Progression Handling
    public ArcanaChallengeData GetChallengeData(string challengeName)
    {
        ArcanaChallengeData found;
        allArcana.TryGetValue(challengeName, out found);
        return found;
    }

    public void SucceededChallenge(ArcanaChallengeData challengeData)
    {
        completedArcana.Add(challengeData.ArcanaName, challengeData);
    }

    public void FailedChallenge(ArcanaChallengeData challengeData, Descriptors.ChallengeFailure reason)
    {
        failedArcana.Add(challengeData.ArcanaName, challengeData);
    }

    // Scrap previous Arena Challenge Manager, Play Tarot Draw, Set new Arena Challenge Manager
    public void ProgressToNextChallenge()
    {

    }

    public void PrepareChallenge(ArcanaChallengeData challenge)
    {

    }
    #endregion
}