using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeManager : MonoBehaviour
{
    private readonly List<ChargeData> charges = new List<ChargeData>();
    private void Update() => ProcessCharges();

    public void SetCharge(IHasChargeTime chargeTime) {
        charges.Add(new ChargeData(chargeTime));
    }

    public bool IsCharging(int id)
    {
        foreach(ChargeData charge in charges)
        {
            if (charge.Id == id) { return true; }
        }

        return false;
    }

    public float GetRemainingDuration(int id)
    {
        foreach (ChargeData charge in charges)
        {
            if (charge.Id != id) { continue; }

            return charge.RemainingTime;
        }

        return 0f;
    }

    private void ProcessCharges()
    {
        float deltaTime = Time.deltaTime;

        for (int i = charges.Count - 1; i >= 0; i--)
        {
            if (charges[i].DecrementChargetime(deltaTime))
            {
                charges.RemoveAt(i);
            }
        }
    }
}

public class ChargeData
{
    public ChargeData(IHasChargeTime charge) 
    {
        Id = charge.chargeId;
        RemainingTime = charge.ChargeDuration;

    }

    public int Id { get; }
    public float RemainingTime {get; private set;}

    public bool DecrementChargetime(float deltaTime)
    {
        RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0f);
        return RemainingTime == 0;
    }
}
