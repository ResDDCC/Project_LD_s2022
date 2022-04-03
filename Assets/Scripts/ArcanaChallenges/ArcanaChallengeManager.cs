using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcanaChallengeManager : MonoBehaviour
{
    [SerializeField]
    protected string challengeDataName;
    [SerializeField]
    protected ArcanaChallengeData challengeData;

    [SerializeField]
    protected List<List<GameObject>> waves = new List<List<GameObject>>();
    [SerializeField]
    protected int waveCount;

    protected Descriptors.ChallengeFailure reason;

    protected void Awake()
    {
        challengeData = ProgressionStore.Instance.GetChallengeData(challengeDataName);
        //float timeForChallenge = challengeData.TimeProvided;
    }

    protected void Start()
    {
        ProgressionStore.Instance.PrepareChallenge(challengeData);
    }

    // Terrain changes, etc for the current upcoming challenge set here
    public void PrepareArena()
    {

    }

    // Buff and/or Debuff Player
    public void PreparePlayers(ArcanaChallengeData challengeData)
    {
        // Give players buff data
        foreach (PlayerData data in ProgressionStore.Instance.playersData)
        {
            List<PlayerBuffData> playerBuffData = new List<PlayerBuffData>();
            foreach (ArcanaChallengeData challenge in ProgressionStore.Instance.completedArcana.Values)
            {
                playerBuffData.Add(challenge.PlayerBuff);
            }
            data.Buffs = playerBuffData;
        }

        // Clear current player buff effects

        // Tell Players to Register their Buffs
        foreach (GameObject player in ProgressionStore.Instance.activePlayers)
        {
            player.GetComponent<PlayerController>().RegisterBuffs();
        }
    }

    // Initiate Timer, enemy AI, etc.
    public void StartChallenge()
    {

    }

    protected void FinishChallenge(bool success)
    {
        // Stop Enemy AI, Timer, etc.

        // Log Results
        if (success)
        {
            ProgressionStore.Instance.SucceededChallenge(challengeData);
        }
        else
        {
            ProgressionStore.Instance.FailedChallenge(challengeData, reason);
        }
        //
        //
        //
        ClearArena();
    }

    // Remove all enemies, reset to neutral for next Challenge
    public void ClearArena()
    {

    }
}
