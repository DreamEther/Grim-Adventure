using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sits on the object Character Select in scene
public class PlayerParty : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] public List<GameObject> characters;
    [SerializeField] public List<GameObject> playerOneStartingMinion;

    //[SerializeField] public List<GameObject> spawnTwoPlayers;
    public static PlayerParty instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddCharacterToParty(GameObject character)
    {
        characters.Add(character);
        sceneLoader.LoadNextScene();
    }

    public void AddCharacterToParty2(GameObject character)
    {
        characters.Add(character);
        sceneLoader.LoadNextScene();
    }



    public void AddStartingMinionToList(GameObject minion)
        {
          playerOneStartingMinion.Add(minion);
        }
        
            
}
