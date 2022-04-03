using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcanaChallengeArenaManager : MonoBehaviour
{

    [SerializeField]
    protected ArcanaChallengeData challengeData;

    [SerializeField] 
    protected List<List<GameObject>> waves = new List<List<GameObject>>();

    [SerializeField] 
    protected int waveCount;

    [SerializeField] 
    protected float timeProvided;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
