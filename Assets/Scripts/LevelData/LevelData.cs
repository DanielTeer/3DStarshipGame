using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public float playerYLimit = 30f;//Invisible ceiling height for this level

    public Transform spawnedObjectsParent;//Where spawned objects are placed in the Hierarchy

    public int minimumSpawnPoints = 3;//Lowest number of spawn points

    public int maximumSpawnPoints = 6;//Highest number of spawn points

    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();//All spawn points in this level

    private void Awake()
    {
        FindSpawnPoints();//Automatically find all spawn points in this level

        SpawnRandomSpawnPoints();//Randomly choose spawn points and spawn their objects
    }

    private void FindSpawnPoints()
    {
        spawnPoints.Clear();//Clear old list

        SpawnPoint[] foundSpawnPoints = GetComponentsInChildren<SpawnPoint>();//Find spawn points under this level

        spawnPoints.AddRange(foundSpawnPoints);//Add found spawn points to list
    }

    private void SpawnRandomSpawnPoints()
    {
        if (spawnPoints.Count <= 0)//No spawn points exist
        {
            return;
        }

        if (maximumSpawnPoints < minimumSpawnPoints)//Stops bad designer values
        {
            maximumSpawnPoints = minimumSpawnPoints;//Fix max if it is too low
        }

        int spawnAmount = Random.Range(minimumSpawnPoints, maximumSpawnPoints + 1);//Pick random number of spawn points

        if (spawnAmount > spawnPoints.Count)//If trying to spawn more than available
        {
            spawnAmount = spawnPoints.Count;//Limit to available spawn points
        }

        List<SpawnPoint> unusedSpawnPoints = new List<SpawnPoint>();//Temporary list

        unusedSpawnPoints.AddRange(spawnPoints);//Copy all spawn points into temporary list

        for (int i = 0; i < spawnAmount; i++)//Repeat for the random spawn amount
        {
            int randomIndex = Random.Range(0, unusedSpawnPoints.Count);//Pick random spawn point index

            SpawnPoint chosenSpawnPoint = unusedSpawnPoints[randomIndex];//Get chosen spawn point

            chosenSpawnPoint.Spawn(spawnedObjectsParent);//Tell spawn point to spawn its prefab

            unusedSpawnPoints.RemoveAt(randomIndex);//Remove so this spawn point cannot be used twice
        }
    }
}