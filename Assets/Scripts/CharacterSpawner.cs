using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    PlayerParty playerParty;

    [SerializeField] Image[] spawnPoint = null;
    [SerializeField] GameObject ninjaPrefab;
    [SerializeField] GameObject dragonPrefab;

    private Vector3 firstSpawnPoint;
    private Vector3 secondSpawnPoint;
    private Vector3 thirdSpawnPoint;

    private GameObject lane1PF;
    private GameObject lane2PF;
    private GameObject lane3PF;

    public static GameObject playerOne;
    public static GameObject playerTwo;
    public static GameObject playerThree;

    // Start is called before the first frame update
    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();

        Vector3 YPosOffset = new Vector3(0, 40, 0);
        firstSpawnPoint = Camera.main.ScreenToWorldPoint(spawnPoint[0].transform.position + YPosOffset);
        firstSpawnPoint.z = 0;
        secondSpawnPoint = Camera.main.ScreenToWorldPoint(spawnPoint[1].transform.position + YPosOffset);
        secondSpawnPoint.z = 0;
        thirdSpawnPoint = Camera.main.ScreenToWorldPoint(spawnPoint[2].transform.position + YPosOffset);
        thirdSpawnPoint.z = 0;

        SpawnPlayerOneInPlayerParty();
        SpawnPlayerTwoInPlayerParty();
        SpawnPlayerThreeInPlayerParty();
    }

    public void SpawnPlayerOneInPlayerParty()
    {
        playerOne = Instantiate(playerParty.characters[0], firstSpawnPoint, Quaternion.identity);
    }

    public void SpawnPlayerTwoInPlayerParty()
    {
        if (playerParty.characters.Count <= 1)
        {
            return;
        }
        playerTwo = Instantiate(playerParty.characters[1], secondSpawnPoint, Quaternion.identity);
    }

    public void SpawnPlayerThreeInPlayerParty()
    {
        if (playerParty.characters.Count <= 2)
        {
            return;
        }
        playerThree = Instantiate(playerParty.characters[2], thirdSpawnPoint, Quaternion.identity);
    }   
}
