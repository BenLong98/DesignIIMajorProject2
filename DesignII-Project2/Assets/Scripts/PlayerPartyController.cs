using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyController : MonoBehaviour
{

    public static PlayerPartyController instance;
    //public GameObject playerCanvas;
    public List<GenericPlayerChar> playerCharacterList;
    public List<GenericPlayerChar> enemyCharacterList;
    public List<GenericPlayerChar> playerParty;
    public List<GenericPlayerChar> enemyParty;
    private int slotNumber;
    public static bool notAcceptable;
    public static bool partyFull;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        //uncomment this out if you're done testing
        //gameObject.SetActive(false);
    }

    private void Start()
    {
        playerParty[0] = playerCharacterList[0];
        playerParty[1] = playerCharacterList[1];
        playerParty[2] = playerCharacterList[2];
        CharacterSelection.highlightIsActive[0] = true;
        CharacterSelection.highlightIsActive[1] = true;
        CharacterSelection.highlightIsActive[2] = true;
        Debug.Log(CharacterSelection.highlightIsActive[0]);
        //Debug.Log(SceneController.instance.publicCurrentScene);

        slotNumber = 0;
    }

    public void StartBattle()
    {
        gameObject.SetActive(true);
    }

    public void EndBattle()
    {
        gameObject.SetActive(false);
    }

    public void CheckForDuplicates(int classNumber)
    {
        foreach (GenericPlayerChar toCheckIfAddCharacter in playerParty)
        {
            if (toCheckIfAddCharacter == playerCharacterList[classNumber])
            {
                notAcceptable = true;
            }
        }
    }

    void CheckTempHolder(string tempHolderClassName)
    {
        if (tempHolderClassName == "Barbarian")
        {
            CharacterSelection.highlightIsActive[0] = false;
        }
        if (tempHolderClassName == "Cleric")
        {
            CharacterSelection.highlightIsActive[1] = false;
        }
        if (tempHolderClassName == "Knight")
        {
            CharacterSelection.highlightIsActive[2] = false;
        }
        if (tempHolderClassName == "Ranger")
        {
            CharacterSelection.highlightIsActive[3] = false;
        }
        if (tempHolderClassName == "Rogue")
        {
            CharacterSelection.highlightIsActive[4] = false;
        }
        if (tempHolderClassName == "Wizard")
        {
            CharacterSelection.highlightIsActive[5] = false;
        }
    }


    public void AddCharacter(int classNumber)
    {
        CheckForDuplicates(classNumber);
        if (notAcceptable == true)
        {
            Debug.Log("This is not acceptable");
        }
        else
        {
            foreach (GenericPlayerChar toAddCharacter in playerParty)
            {
                if (toAddCharacter == null)
                {
                    slotNumber = playerParty.IndexOf(toAddCharacter);
                }
            }
            GenericPlayerChar tempHolder = playerParty[slotNumber];
            playerParty[slotNumber] = playerCharacterList[classNumber];
            string tempHolderClassName = tempHolder.classType.ToString();
            CheckTempHolder(tempHolderClassName);
            slotNumber++;
            if (slotNumber > 2)
            {
                slotNumber = 0;
            }
            Debug.Log(playerParty[0].classType);
            Debug.Log(playerParty[1].classType);
            Debug.Log(playerParty[2].classType);
        }
    }

    public void RemoveCharacter(int classNumber)
    {
        foreach (GenericPlayerChar toRemoveCharacter in playerParty)
        {
            if (toRemoveCharacter == playerCharacterList[classNumber])
            {
                //playerParty.Remove(toRemoveCharacter);
                //CharacterSelection.highlightIsActive[classNumber] = false;
            }
        }
        Debug.Log(playerParty[0].classType);
        Debug.Log(playerParty[1].classType);
        Debug.Log(playerParty[2].classType);
    }
}
