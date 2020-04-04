using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sits on the object Character Select in scene
public class PlayerParty : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] public List<GameObject> characters;
    [SerializeField] public List<GameObject> playerOneStartingMinion;
    [SerializeField] public List<GameObject> spawnTwoPlayers;
    [SerializeField] public AttackSequence defaultNinjaSequence;
    [SerializeField] public AttackSequence defaultDragoonSequence;
    [SerializeField] public GameObject rushPrefab;

    #region Singleton
    public static PlayerParty instance;
    void Awake()
    {     
        if (instance != null)
        {
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
        playerOneStartingMinion = new List<GameObject>();
    }

    #endregion

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddCharacterToParty(GameObject character)
    {
            characters.Add(character);  
            sceneLoader.LoadNextScene();
    }


    //need this to spawn two different prefabs on one button click. probably won't use anyway
    public void AddCharacterToParty2(GameObject character)
    {
        characters.Add(character);
        sceneLoader.LoadNextScene();
    }

        
}
