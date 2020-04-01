using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private float randomEnemyCount;
    [SerializeField] private List<GameObject> enemies = null;
    [SerializeField] public List<Image> spawnPoint = null;
  //  [SerializeField] GameObject dragon;
    void Awake()
    {        
        randomEnemyCount = Random.Range(2, 6);
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newVec = new Vector3(0.1f, -2.9f, 0);
        //dragon = Instantiate(dragon, newVec, Quaternion.LookRotation(transform.forward));
        SpawnEnemies();
      //  Debug.Log(dragon.transform.position);
    }

    private void SpawnEnemies()
    {
        Vector3 xOffset = new Vector3(0, 0, -90); // clones were at 90 on the Z axis for some reason...this was the simple fix. 
        for (int i = 0; i < randomEnemyCount - 1; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count - 1)], spawnPoint[Random.Range(0, spawnPoint.Count - 1)].transform.position + xOffset, Quaternion.LookRotation(enemies[0].transform.forward));
        }
    }
}
