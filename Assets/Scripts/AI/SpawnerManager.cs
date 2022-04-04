using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public enum Arcana 
    {
        Strength, 
        Temperance, 
        Tower
    }

    HashSet<Arcana> activeArcana = new HashSet<Arcana>();
    Dictionary<int, List<int>> instructions;
    public bool spawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        // make sure instructions are sent from arcana
        // update active arcana
        spawnTime = true;

        //testing spawner
        List<int> test = new List<int>();
        test.Add(0);
        test.Add(2);
        test.Add(1);

        instructions = new Dictionary<int, List<int>>();
        instructions.Add(0, test);

    }

    // Update is called once per frame
    void Update()
    {
        // check for wave completion and updates from challenge managers
        if (spawnTime)
        {
            InstructSpawners();
        }
    }

    void InstructSpawners() 
    {
        foreach (KeyValuePair<int, List<int>> entry in instructions) 
        {
            Spawner spawner = transform.GetChild(entry.Key).GetComponent<Spawner>();
            spawner.SetPattern(entry.Value);
        }
    }
}
