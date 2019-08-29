using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private float randomEnemyCount;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] Image spawnPoint;
    Vector3 cameraPos;
   // Camera camera;
   // [SerializeField] List<>
    void Awake()
    {
      //  camera = Camera.main
        randomEnemyCount = Random.Range(2, 4);
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 YPosOffset = new Vector3(0, 40, 0);
        cameraPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        var localSpawnPoint = Camera.main.ScreenToWorldPoint(spawnPoint.transform.position + YPosOffset);
        localSpawnPoint.z = 0;
        Instantiate(enemies[0], localSpawnPoint, Quaternion.LookRotation(enemies[0].transform.forward)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < randomEnemyCount - 1; i++)
        {
          // Instantiate(enemies[i], lane1EF.transform.position, Quaternion.LookRotation(dragonPrefab.transform.forward));
        }
    }
}
