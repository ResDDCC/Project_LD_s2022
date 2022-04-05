using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasChargeTime
{
    int chargeId { get; }

    float ChargeDuration { get; }
}
