using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    PlayerParty playerParty;
    [SerializeField] public static GameObject lane1P;
    [SerializeField] public static GameObject lane2P;
    [SerializeField] public static GameObject lane3P;
    [SerializeField] public static GameObject lane1E;
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
        lane1P = GameObject.FindGameObjectWithTag("Lane1P");
        lane2P = GameObject.FindGameObjectWithTag("Lane2P");
        lane3P = GameObject.FindGameObjectWithTag("Lane3P");
        lane1E = GameObject.FindGameObjectWithTag("Lane1E");

        SpawnPlayerOneInPlayerParty();
        SpawnPlayerTwoInPlayerParty();
        SpawnPlayerThreeInPlayerParty();
    }

    void Update()
    {

    }

    public void SpawnPlayerOneInPlayerParty()
    {
        playerOne = Instantiate(playerParty.characters[0], lane1P.transform.position, Quaternion.identity);
    }

    public void SpawnPlayerTwoInPlayerParty()
    {
        if (playerParty.characters.Count <= 1)
        {
            return;
        }
        playerTwo = Instantiate(playerParty.characters[1], lane2P.transform.position, Quaternion.identity);
    }

    public void SpawnPlayerThreeInPlayerParty()
    {
        if (playerParty.characters.Count <= 2)
        {
            return;
        }
        playerThree = Instantiate(playerParty.characters[2], lane3P.transform.position, Quaternion.identity);
    }
    private void SpawnDragon()
    {
        Instantiate(dragonPrefab, lane1E.transform.position, Quaternion.LookRotation(dragonPrefab.transform.forward));
    }

    
}
