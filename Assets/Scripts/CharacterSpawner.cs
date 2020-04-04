using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{

    [SerializeField] List<Image> spawnPoint = null;
  
    [SerializeField] GameObject ninjaPrefab;
   // [SerializeField] GameObject dragonPrefab;

    //private Vector3 firstSpawnPoint;
    //private Vector3 secondSpawnPoint;
    //private Vector3 thirdSpawnPoint;
    
    private GameObject lane1PF;
    private GameObject lane2PF;
    private GameObject lane3PF;

    public static GameObject playerOne;
    public static GameObject playerTwo;
    public static GameObject playerThree;

    [SerializeField] Vector3 spawnOffset;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerParty.instance.characters.Count == 1)
        {
            SpawnPlayerOneInPlayerParty();
        }
        else if (PlayerParty.instance.characters.Count == 2)
        {
            SpawnTwoPlayers();
        }

    }

    private void Update()
    {
    }

    public void SpawnPlayerOneInPlayerParty()
    {
        playerOne = Instantiate(PlayerParty.instance.characters[0], spawnPoint[Random.Range(0, spawnPoint.Count - 1)].transform.position + spawnOffset, Quaternion.identity);
    }
    public void SpawnTwoPlayers()
    {
        playerOne = Instantiate(PlayerParty.instance.characters[0], spawnPoint[0].transform.position + spawnOffset, Quaternion.identity);
        playerTwo = Instantiate(PlayerParty.instance.characters[1], spawnPoint[1].transform.position + spawnOffset, Quaternion.identity);

    }

    public void SpawnPlayerTwoInPlayerParty()
    {
        if (PlayerParty.instance.characters.Count <= 1)
        {
            return;
        }
        playerTwo = Instantiate(PlayerParty.instance.characters[1], spawnPoint[1].transform.position + spawnOffset, Quaternion.identity);
    }

    public void SpawnPlayerThreeInPlayerParty()
    {
        if (PlayerParty.instance.characters.Count <= 2)
        {
            return;
        }
        playerThree = Instantiate(PlayerParty.instance.characters[2], spawnPoint[2].transform.position + spawnOffset, Quaternion.identity);
    }   
}
