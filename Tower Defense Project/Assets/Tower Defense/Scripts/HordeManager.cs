using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    public Wave enemyWave;
    public Path enemyPath;

    IEnumerator Start()
    {
        StartCoroutine("SpawnSmallEnemies");
        StartCoroutine("SpawnBigEnemies");
        
        yield break;
    }


    IEnumerator SpawnSmallEnemies()
    {
        for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
        {
            for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfSmall; j++)
            {
                Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].smallEnemy).GetComponent<Enemy>();
                spawnedEnemy.route = enemyPath;
                yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenSmallEnemies);

            }

            yield return new WaitForSeconds(enemyWave.coolDownBetweenSmallWave);
        }
    }

    IEnumerator SpawnBigEnemies()
    {
        for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
        {
            for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfLarge; j++)
            {
                Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].LargeEnemy).GetComponent<Enemy>();
                spawnedEnemy.route = enemyPath;
                yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenLargeEnemies);

            }

            yield return new WaitForSeconds(enemyWave.coolDownBetweenLargeWave);
        }
    }
}



[Serializable]
public struct Group
{
    public GameObject smallEnemy;
    public GameObject LargeEnemy;
    public int numberOfSmall;
    public int numberOfLarge;
    public float coolDownBetweenSmallEnemies;
    public float coolDownBetweenLargeEnemies;

}

[Serializable]
public struct Wave
{
    public Group[] groupsOfEnemiesInWave;
    public float coolDownBetweenSmallWave;
    public float coolDownBetweenLargeWave;
}