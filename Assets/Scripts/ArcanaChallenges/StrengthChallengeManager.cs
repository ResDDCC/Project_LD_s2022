using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthChallengeManager : ArcanaChallengeManager
{
    protected void Awake()
    {
        challengeDataName = "Strength";
        challengeData = ProgressionStore.Instance.GetChallengeData(challengeDataName);
        //float timeForChallenge = challengeData.TimeProvided;
    }

    protected void Start()
    {
        Debug.Log("Challenge Begins!");
        //ProgressionStore.Instance.PrepareChallenge(challengeData);
        currTime = challengeData.TimeProvided;
        currWave = 0;
        isComplete = false;
        PreparePlayers(challengeData);
        //Apply enemy buffs to the enemies 

        // get spawner manager for wave spawning
        spawnerManager = GameObject.FindGameObjectWithTag("SpawnerManager").GetComponent<SpawnerManager>();

        // loads the first wave into the SpawnerManager which sets up and waits for StartChallenge() to start spawning
        SpawnWave(currWave);
        StartChallenge();

    }

    private void Update() {
        if(CheckWaveComplete()) {
            //update wave
            currWave += 1;

            if (currWave >= 3) {
                isComplete = true;
                FinishChallenge(isComplete);
            } else {
                SpawnWave(currWave);
            }
        } else {
            //check for failure
            if (!CheckForFailure(currTime)) {
                FinishChallenge(CheckForFailure(currTime));
            }
        }
        UpdateTimer();
    }

    public override void StartChallenge()
    {
        // just tells the spawner manager that it can start churning out monsters. 
        // preferable if this is called AFTER the first wave has been loaded into the SpawnerManager
        spawnerManager.StartSpawn();
    }

    public override void PrepareArena()
    {

    }

    public override void SpawnWave(int currWave)
    {
        // switch(currWave) {
        //     case 0:
        //         for (int i = 0; i < waves[currWave].Count; i++) {
        //             waves[currWave][i].SetActive(true);
        //         }
        //         break;
        //     case 1:
        //         for (int i = 0; i < waves[currWave].Count; i++) {
        //             waves[currWave][i].SetActive(true);
        //         }
        //         break;
        //     case 2:
        //         for (int i = 0; i < waves[currWave].Count; i++) {
        //             waves[currWave][i].SetActive(true);
        //         }
        //         break;
        // }

        // to send a wave of enemies to the spawner manager, do spawnerManagger.AddWave(spawnerID, wavePattern)
        // spawnerID should be an int, wavePattern should be List<int>
        // NOTE: when placing your spawners in the world, the Spawner Manager is going to index them by child index number (first child = index 0 and so on).
        // MAKE SURE YOU STICK TO ONE SPAWNER ID CONVENTION SO THAT THIS DOESN'T GET MESSED UP
        switch(currWave) {
            case 0:
                // THIS IS JUST A SAMPLE
                spawnerManager.AddWave(0, new List<int>(new int[] {0, 1, 2}));
                break;
            case 1:
                spawnerManager.AddWave(0, new List<int>(new int[] {0, 1, 2}));
                spawnerManager.AddWave(1, new List<int>(new int[] {2, 0, 1}));
                break;
            case 2:
                spawnerManager.AddWave(1, new List<int>(new int[] {0, 1, 2}));
                spawnerManager.AddWave(0, new List<int>(new int[] {2, 0, 1}));
                break;
        }
    }

    public bool CheckWaveComplete()
    {
        bool allDead = false;

        // replaced the check here with a spawnerManager method that tells you whether all the enemies are clear or not
        if (spawnerManager.WaveComplete()) {
            allDead = true;
            // maybe implement a delay here so enemies aren't spawning as soon as the last wave is dead
            spawnerManager.StartSpawn();
        }
        return allDead;
    }

    public override bool CheckForFailure(float currTime)
    {
        if (currTime <= 0) {
            reason = Descriptors.ChallengeFailure.TimeLoss;
            return false;
        } else {
            if (CheckPlayerDeath()) {
                reason = Descriptors.ChallengeFailure.Death;
                return false;
            }
            return true;
        }
    }
    public override void ClearArena()
    {
        Debug.Log("Challenge is over!");
    }

}
