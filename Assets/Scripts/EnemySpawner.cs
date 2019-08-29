using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private float randomEnemyCount;
    [SerializeField] private List<GameObject> enemies = null;
    [SerializeField] private List<Image> spawnPoint = null;

    void Awake()
    {        
        randomEnemyCount = Random.Range(2, 6);
    }
    // Start is called before the first frame update
    void Start()
    {
      
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        Vector3 YPosOffset = new Vector3(0, 40, 0);
        for (int i = 0; i < randomEnemyCount; i++)
        {
            var localSpawnPoint = Camera.main.ScreenToWorldPoint(spawnPoint[Random.Range(0, spawnPoint.Count - 1)].transform.position + YPosOffset);
            localSpawnPoint.z = 0;
            Instantiate(enemies[Random.Range(0, enemies.Count - 1)], localSpawnPoint, Quaternion.LookRotation(enemies[0].transform.forward));
        }
    }
}
