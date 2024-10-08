using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;
    private MyTimer spawnTimer;

    private void Awake() 
    {
        spawnTimer = new MyTimer();
        spawnTimer.InitializeTimer(2, true);
        spawnTimer.OnTimerEnd += SpawnEnemy;
    }    

    private void Update() 
    {
        spawnTimer.TickTimer(Time.deltaTime);
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemiesList[UnityEngine.Random.Range(0, enemiesList.Count)];
        GameObject spawnedEnemy = Instantiate(enemy, spawnPoint.position, quaternion.identity);

        MoveManager.instance.AddMovableEntityToList(spawnedEnemy.GetComponent<MoveBase>());
    }
}
