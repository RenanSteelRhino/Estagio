using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnDuration = 5;
    private MyTimer spawnTimer;

    private void Awake() 
    {
        spawnTimer = new MyTimer();
        spawnTimer.InitializeTimer(spawnDuration, true);
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

        spawnDuration = UnityEngine.Random.Range(2f, 10f);
        spawnTimer.InitializeTimer(spawnDuration, true);
    }
}
