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
        spawnTime = false;

        // //testing spawner
        // List<int> test = new List<int>();
        // test.Add(0);
        // test.Add(2);
        // test.Add(1);

        // instructions = new Dictionary<int, List<int>>();
        // instructions[0] = test;
        // //Debug.Log(instructions[0]);

        // List<int> test2 = new List<int>();
        // test2.Add(1);
        // test2.Add(0);
        // test2.Add(2);
        // test2.Add(0);
        // test2.Add(2);
        // test2.Add(1);

        // instructions[1] = test2;
        // //Debug.Log(instructions[1]);

        // InstructSpawners();
    }

    // Update is called once per frame
    void Update()
    {
        // check for wave completion and updates from challenge managers
        if (spawnTime)
        {
            InstructSpawners();
            spawnTime = false;
            NewWave();
        }
    }

    void InstructSpawners() 
    {
        foreach (KeyValuePair<int, List<int>> entry in instructions) 
        {
            Debug.Log(entry.Key);
            Spawner spawner = transform.GetChild(entry.Key).GetComponent<Spawner>();
            spawner.SetPattern(entry.Value);
        }
    }

    public void AddWave(int spawnID, List<int> wavePattern) 
    {
        instructions.Add(spawnID, wavePattern);
    }

    public void NewWave()
    {
        instructions = new Dictionary<int, List<int>>();
    }

    public void StartSpawn()
    {
        spawnTime = true;
    }

    // returns true if all spawners have their enemies dead
    public bool WaveComplete()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Spawner spawner = transform.GetChild(i).GetComponent<Spawner>();
            if (!spawner.Ready()) { return false; }
        }

        return true;
    }
}
