using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    PlayerParty playerParty;
    [SerializeField] public static GameObject lane1PF;
    [SerializeField] public static GameObject lane2PF;
    [SerializeField] public static GameObject lane3PF;
    [SerializeField] public static GameObject lane1EF;
    [SerializeField] GameObject ninjaPrefab;
    [SerializeField] GameObject dragonPrefab;
    public static GameObject playerOne;
    public static GameObject playerTwo;
    public static GameObject playerThree;
    GameObject[] charsInParty;

    // Start is called before the first frame update
    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
        lane1PF = GameObject.FindGameObjectWithTag("Lane1PF");
        lane2PF = GameObject.FindGameObjectWithTag("Lane2PF");
        lane3PF = GameObject.FindGameObjectWithTag("Lane3PF");
        lane1EF = GameObject.FindGameObjectWithTag("Lane1EF");

        SpawnPlayerOneInPlayerParty();
        SpawnPlayerTwoInPlayerParty();
        SpawnPlayerThreeInPlayerParty();
    }

    void Update()
    {

    }

    public void SpawnPlayerOneInPlayerParty()
    {
        playerOne = Instantiate(playerParty.characters[0], lane1PF.transform.position, Quaternion.identity);
    }

    public void SpawnPlayerTwoInPlayerParty()
    {
        if (playerParty.characters.Count <= 1)
        {
            return;
        }
        playerTwo = Instantiate(playerParty.characters[1], lane2PF.transform.position, Quaternion.identity);
    }

    public void SpawnPlayerThreeInPlayerParty()
    {
        if (playerParty.characters.Count <= 2)
        {
            return;
        }
        playerThree = Instantiate(playerParty.characters[2], lane3PF.transform.position, Quaternion.identity);
    }
    private void SpawnDragon()
    {
        Instantiate(dragonPrefab, lane1EF.transform.position, Quaternion.LookRotation(dragonPrefab.transform.forward));
    }

    
}
