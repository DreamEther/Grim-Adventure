using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLists : MonoBehaviour
{
    public List<GameObject> ninjaMinions;
    public List<GameObject> draygonMinions;
    public List<GameObject> foxMinions;
    private PlayerParty playerParty;
  //  PlayerParty playerParty;

    // Start is called before the first frame update
    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
        ninjaMinions = new List<GameObject>();
        draygonMinions = new List<GameObject>();
        foxMinions = new List<GameObject>();
      //  playerParty = FindObjectOfType<PlayerParty>();
        FindStartingMinion();       
    }

    private void FindStartingMinion()
    {
        if (playerParty.playerOneStartingMinion.Count != 0)
        {
            switch (playerParty.playerOneStartingMinion[0].gameObject.tag)
            {
                case "PocketNinja":
                    ninjaMinions = playerParty.playerOneStartingMinion;
                    break;

                case "WingedBat":
                    draygonMinions = playerParty.playerOneStartingMinion;
                    break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

}
