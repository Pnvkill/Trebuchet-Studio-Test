using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ClockSpawner : MonoBehaviour
{

    public GameObject ClockPrefab;
    public MeshRenderer SpawnArea;
    public int NumberOfSpawn;

    PlayClockSpawnAudio playClockSpawnAudio;
    public AudioSource SpawnSound;

    private float spawnCollisionCheckRadius = 1f;
    private int spawnNbOfRetries = 3;
    private float clockSpawnHeight = 1.5f;
    private Vector3 spawnSize, spawnCenter;

    void Start()
    {
        spawnCenter = SpawnArea.transform.position;
        spawnSize = SpawnArea.GetComponent<MeshRenderer>().bounds.size;
        int spawnAttempt = 0;

        while(NumberOfSpawn != 0) {

            if(SpawnClock() || spawnAttempt == spawnNbOfRetries)
            {
                NumberOfSpawn--;
                spawnAttempt = 0;
            } 
            spawnAttempt++;
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SpawnClock();
        }
    }

    private bool SpawnClock() {
        Vector3 pos = spawnCenter + new Vector3(Random.Range(-spawnSize.x/2, spawnSize.x/2), clockSpawnHeight, Random.Range(-spawnSize.z/2, spawnSize.z/2));
        if(!Physics.CheckSphere(pos, spawnCollisionCheckRadius))
        {
            Instantiate(ClockPrefab, pos, Quaternion.Euler(-90, 0, 0));
            return true;        
        }
        return false;
    }
}
