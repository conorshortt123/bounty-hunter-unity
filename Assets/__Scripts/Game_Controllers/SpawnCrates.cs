using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SpawnCrates : MonoBehaviour
{
    // Private member variables
    [SerializeField] private HealthCrate healthCrate;
    [SerializeField] private RapidFireCrate rpfCrate;
    [SerializeField] private float spawnDelay = 0.25f;
    [SerializeField] private float spawnInterval = 0.35f;

    private const string SPAWN_METHOD = "SpawnOneCrate";

    private IList<SpawnPoint> spawnPoints;

    private Stack<SpawnPoint> spawnStack;

    private GameObject crateParent;

    //private ListUtils listUtils = new ListUtils();

    // == private methods ==
    private void Start()
    {
        crateParent = GameObject.Find("CrateParent");
        if (!crateParent)
        {
            crateParent = new GameObject("CrateParent");
        }
        // get the spawn points here
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        SpawnEnemyWaves();
    }

    private void SpawnEnemyWaves()
    {
        // create the stack of points
        spawnStack = ListUtils.CreateShuffledStack(spawnPoints);
        //InvokeRepeating("SpawnOneEnemy", 0f, 0.25f);
        InvokeRepeating(SPAWN_METHOD, spawnDelay, spawnInterval);
    }

    // stack version
    private void SpawnOneCrate()
    {
        if (spawnStack.Count == 0)
        {
            spawnStack = ListUtils.CreateShuffledStack(spawnPoints);
        }

        var sp = spawnStack.Pop();

        if (healthCrate)
        {
            Instantiate(healthCrate, crateParent.transform);
            healthCrate.transform.position = sp.transform.position;
        } 
        if(rpfCrate)
        {
            Instantiate(rpfCrate, crateParent.transform);
            rpfCrate.transform.position = sp.transform.position;
        }
    }
}
