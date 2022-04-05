using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasCooldown
{
    int CoolId { get; }

    float CooldownDuration { get; }
}
