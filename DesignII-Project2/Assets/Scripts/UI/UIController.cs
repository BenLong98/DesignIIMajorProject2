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
    public List<Sprite> buttonSprites;

    [Header("UniversalUI")]
    public Button quitButton;
    public Button gearButton;
    public Button mainMenuButton;
    public GameObject gearPanel;

    [SerializeField] GameObject gameHandler;

    void Start ()
    {
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
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

    public void OnClickPlayButton()
    {
        gameHandler.GetComponent<GameHandler>().isInMenu = false;
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        gameHandler.GetComponent<GameHandler>().doneCreating = true;
        gameHandler.GetComponent<GameHandler>().CheckMenus();
        SceneController.instance.CharacterSelectionSceneProgression();
    }

    public void SwitchAttackButtonVisibility(bool isActive, bool isActive2)
    {
        attack1Button.interactable = isActive;
        attack2Button.interactable = isActive2;
    }

    public void ChangeAttackButtonText()
    {
        if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Smash";
            attack1Button.GetComponent<Image>().sprite = buttonSprites[0];
            attack2Button.GetComponentInChildren<Text>().text = "Aggro";
            attack2Button.GetComponent<Image>().sprite = buttonSprites[5];
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Cleric)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Heal One";
            attack1Button.GetComponent<Image>().sprite = buttonSprites[2];
            attack2Button.GetComponentInChildren<Text>().text = "Heal All";
            attack2Button.GetComponent<Image>().sprite = buttonSprites[3];
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Knight)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Slash";
            attack1Button.GetComponent<Image>().sprite = buttonSprites[0];
            attack2Button.GetComponentInChildren<Text>().text = "Shield";
            attack2Button.GetComponent<Image>().sprite = buttonSprites[5];
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Ranger)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Arrow";
            attack2Button.GetComponentInChildren<Text>().text = "Snipe";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Stab";
            attack2Button.GetComponentInChildren<Text>().text = "Evasion";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Lightning Bolt";
            attack2Button.GetComponentInChildren<Text>().text = "Fireball";
        }
    }
}
