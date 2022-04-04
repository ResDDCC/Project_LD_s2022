using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArcanaChallengeManager : MonoBehaviour
{
    [SerializeField]
    protected string challengeDataName;
    [SerializeField]
    protected ArcanaChallengeData challengeData;

    [SerializeField]
    protected List<List<GameObject>> waves = new List<List<GameObject>>();
    
    protected int waveTotal;

    [SerializeField]
    protected int currWave;
    [SerializeField]
    protected bool isComplete;

    [SerializeField]
    protected float currTime;
    protected Descriptors.ChallengeFailure reason;

    protected SpawnerManager spawnerManager;

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

    protected float UpdateTimer()
    {
        if (currTime > 0) {
            currTime -= Time.deltaTime;
            return currTime;
        } else {
            return 0.0f;
        }
    }

    protected bool CheckPlayerDeath() {
        int playersDead = 0;
        for (int i = 0; i < ProgressionStore.Instance.playersData.Count; i++) {
            if (ProgressionStore.Instance.playersData[i].health <= 0) {
                playersDead++;
            }
        }

        if (playersDead >= ProgressionStore.Instance.playersData.Count) {
            return false;
        } else {
            return true;
        }
    }


    public abstract bool CheckForFailure(float currTime);
        // Terrain changes, etc for the current upcoming challenge set here
    public abstract void PrepareArena();

    public abstract void SpawnWave(int waveCount);

    
    // Initiate Timer, enemy AI, etc.
    public abstract void StartChallenge();

    // Remove all enemies, reset to neutral for next Challenge
    public abstract void ClearArena();
}


