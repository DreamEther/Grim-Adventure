using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{

    [SerializeField] public static GameObject lane1P;
    [SerializeField] public static GameObject lane1E;
    [SerializeField] GameObject ninjaPrefab;
    [SerializeField] GameObject dragonPrefab;
    GameObject ninja;

    // Start is called before the first frame update
    void Start()
    {
        lane1P = GameObject.FindGameObjectWithTag("Lane1P");
        lane1E = GameObject.FindGameObjectWithTag("Lane1E");

        SpawnDragon();
      //  SpawnNinja();
    }

    void Update()
    {

    }

    private void SpawnNinja()
    {
        ninja = Instantiate(ninjaPrefab, lane1P.transform.position, Quaternion.identity) as GameObject;
        
    }

  
    private void SpawnDragon()
    {
        Instantiate(dragonPrefab, lane1E.transform.position, Quaternion.LookRotation(dragonPrefab.transform.forward));
    }
}
