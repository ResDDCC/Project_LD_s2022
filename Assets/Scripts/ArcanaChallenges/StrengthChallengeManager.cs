using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthChallengeManager : ArcanaChallengeArenaManager
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Begin Strength Challenge");

        this.waveCount = 0;
        //this.timeProvided = StrengthChallengeData.timeProvided;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
