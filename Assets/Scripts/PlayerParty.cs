using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{

    [SerializeField] List<BaseCharacter> characters = new List<BaseCharacter>();

    public void AddNinjaToList(BaseCharacter character)
    {
        characters.Add(character);
    }


}
