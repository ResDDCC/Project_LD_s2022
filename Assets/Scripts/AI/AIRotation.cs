using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRotation : MonoBehaviour
{
    //TO DO: dynamically find the player for when these are spawned through the spawner
    [SerializeField] private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        // uncomment for super cool flippy rotation
        //transform.up = player.transform.position - transform.position;
        
        // regular boring rotation
        Vector3 rot = player.transform.position - transform.position;
        transform.up = new Vector3(rot.x, rot.y, 0);
    }
}
