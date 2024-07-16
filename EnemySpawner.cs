using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    [SerializeField] bool isLooping;
   
    
    void Start()    
    {
        StartCoroutine (SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    //void SpawnEnemies()
   // {
   //     for(int i = 0; i < currentWave.GetEnemyCount(); i++) // this will spawn the enemies ontop of eahcother, delay needed
    //    {Instantiate(currentWave.GetEnemyPrefab(0), //calling the WaveConfigSO to find 1st Prefab
     //               currentWave.GetStartingWaypoint().position, //calling tWaveConfigso for waypoint info
       //             Quaternion.identity, //Quaternion - represents rotation, identity = no rotation not identFy
         //           transform); //puts the clones into parent i.e spawner
        //}
    //}

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++) // this will spawn the enemies ontop of eahcother, delay needed
                {   
                    Instantiate(currentWave.GetEnemyPrefab(i), //calling the WaveConfigSO to find 1st Prefab
                        currentWave.GetStartingWaypoint().position, //calling tWaveConfigso for waypoint info
                        Quaternion.Euler(0,0,180), //Quaternion - represents rotation, identity = no rotation not identFy Eueler means xyz 'famous math guy'
                        transform); //puts the clones into parent i.e spawner
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime()); //
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(isLooping);
        
    }

}
