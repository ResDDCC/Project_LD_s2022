using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperanceChallengeManager : ArcanaChallengeManager
{
    protected void Awake()
    {
        challengeDataName = "Temperance";
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
        
    }

    public override void PrepareArena()
    {
        
    }

    public override void SpawnWave(int currWave)
    {
        switch(currWave) {
            case 0:
                for (int i = 0; i < waves[currWave].Count; i++) {
                    waves[currWave][i].SetActive(true);
                }
                break;
            case 1:
                for (int i = 0; i < waves[currWave].Count; i++) {
                    waves[currWave][i].SetActive(true);
                }
                break;
            case 2:
                for (int i = 0; i < waves[currWave].Count; i++) {
                    waves[currWave][i].SetActive(true);
                }
                break;
        }
    }

    public bool CheckWaveComplete()
    {
        bool allDead = false;
        if (waves[currWave].Count == 0) {
            allDead = true;
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
