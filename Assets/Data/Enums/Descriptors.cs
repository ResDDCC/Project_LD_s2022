using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descriptors
{
    public enum ChallengeFailure
    {
        TimeLoss,
        Death,
        TaskFailure
    }

    public enum PlayerState
    {
        Frozen,
        Moving,
        Attacking
    }
}
