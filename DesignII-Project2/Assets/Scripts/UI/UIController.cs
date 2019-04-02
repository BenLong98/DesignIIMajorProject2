using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [Header("CharacterSelectionExclusiveUI")]
    public Button startBattleButton;

    [Header("BattleSceneExclusiveUI")]
    public Button attack1Button;
    public Button attack2Button;
    public Text resultsText;

    [Header("UniversalUI")]
    public Button quitButton;
    public Button gearButton;
    public Button mainMenuButton;
    public GameObject gearPanel;

    void Start ()
    {
		
	}

    public void OnClickGearButton()
    {
        if(gearPanel.activeInHierarchy == true)
        {
            gearPanel.SetActive(false);
        }
        else
        {
            gearPanel.SetActive(true);
        }
    }


    public void OnClickQuitButton()
    {
        Application.Quit();
    }


    public void OnClickCreditsButton()
    {
        SceneController.instance.CreditsSceneProgression();
    }

    public void OnClickStartBattleButton()
    {
        SceneController.instance.BattleSceneProgression();
    }

    public void OnClickMainMenuButton()
    {
        SceneController.instance.MainMenuSceneProgression();
    }

    public void SwitchAttachButtonVisibility(bool isActive)
    {
        attack1Button.gameObject.SetActive(isActive);
        attack2Button.gameObject.SetActive(isActive);
    }

    public void ChangeAttackButtonText()
    {
        if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Smash";
            attack2Button.GetComponentInChildren<Text>().text = "Aggro";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Cleric)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Heal One";
            attack2Button.GetComponentInChildren<Text>().text = "Heal All";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Knight)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Slash";
            attack2Button.GetComponentInChildren<Text>().text = "Shield";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Ranger)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Arrow";
            attack2Button.GetComponentInChildren<Text>().text = "i forgot";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue)
        {
            attack1Button.GetComponentInChildren<Text>().text = "i forgot";
            attack2Button.GetComponentInChildren<Text>().text = "i also forgot";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Lightning Bolt";
            attack2Button.GetComponentInChildren<Text>().text = "Fireball";
        }
    }
}
