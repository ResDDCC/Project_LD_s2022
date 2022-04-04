using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    // Storing all active cooldowns
    private readonly List<CooldownData> cooldowns = new List<CooldownData>();
    
    private void Update () => ProcessCooldowns();

    public void PutOnCooldown(IHasCooldown cooldown) {
        cooldowns.Add(new CooldownData(cooldown));
    }
    public bool IsOnCooldown(int id)
    {
        // I personally don't like this, I think it can be done more efficiently
        // but I didn't wanna waste time optimizing this one loop at the cost of implementing the feature
        foreach(CooldownData cooldown in cooldowns)
        {
            if (cooldown.Id == id) { return true; }
        }
        return false;
    }

    public float GetRemainingDuration(int id)
    {
        foreach (CooldownData cooldown in cooldowns)
        {
            if (cooldown.Id != id) { continue; }

            return cooldown.RemainingTime;
        }

        return 0f;
    }

    //iterates through active cooldowns backwards and removes any that have run out
    private void ProcessCooldowns() 
    {
        float deltaTime = Time.deltaTime;

        for (int i = cooldowns.Count - 1; i >= 0 ; i--)
        {
            if (cooldowns[i].DecrementCooldown(deltaTime)) 
            {
                cooldowns.RemoveAt(i);
            }
        }
    }
}    

public class CooldownData 
{
    public CooldownData(IHasCooldown cooldown)
    {
        Id = cooldown.Id;
        RemainingTime = cooldown.CooldownDuration;
    }

    public int Id { get; }
    public float RemainingTime { get; private set; }

    // doesn't really need to return bool but saves extra checking later
    public bool DecrementCooldown(float deltaTime) 
    {
        RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0f);
        return RemainingTime == 0;
    }
}
