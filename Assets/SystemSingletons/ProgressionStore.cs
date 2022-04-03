using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton
public class ProgressionStore: MonoBehaviour
{
    public static ProgressionStore Instance { get; private set; }

    // Arcana Challenges Data
    [SerializeField]
    private Dictionary<string, ArcanaChallengeData> completedArcana = new Dictionary<string, ArcanaChallengeData>();
    [SerializeField]
    private Dictionary<string, ArcanaChallengeData> failedArcana = new Dictionary<string, ArcanaChallengeData>();
    [SerializeField]
    private Dictionary<string, ArcanaChallengeData> allArcana = new Dictionary<string, ArcanaChallengeData>();


    // Timer Data
    [SerializeField]
    private float defaultTimeRemaining = 360.0f;
    [SerializeField]
    private float currentTimeRemaining = 0.0f;

    private void Awake()
    {
        // Ensure the Original ProgressionStore is the only one
        if (Instance != null & Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        // Follow-up Instantiation Logic

        currentTimeRemaining = defaultTimeRemaining;
    }
}