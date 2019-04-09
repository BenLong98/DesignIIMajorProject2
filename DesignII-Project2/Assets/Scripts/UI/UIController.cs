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
    public List<Sprite> buttonSprites;

    [Header("UniversalUI")]
    public Button quitButton;
    public Button gearButton;
    public Button mainMenuButton;
    public GameObject gearPanel;

    [SerializeField] GameObject sceneController;
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
        sceneController.GetComponent<SceneController>().CreditsSceneProgression();
    }

    public void OnClickStartBattleButton()
    {
        sceneController.GetComponent<SceneController>().BattleSceneProgression();
    }

    public void OnClickPlayLevelButton()
    {
        SceneController.battleSceneName = "Battle";
        sceneController.GetComponent<SceneController>().CharacterSelectionSceneProgression();
    }

    public void OnClickPlayLevelButton2()
    {
        SceneController.battleSceneName = "Battle2";
        sceneController.GetComponent<SceneController>().CharacterSelectionSceneProgression();
    }

    public void OnClickPlayLevelButton3()
    {
        SceneController.battleSceneName = "Battle3";
        sceneController.GetComponent<SceneController>().CharacterSelectionSceneProgression();
    }

    public void OnClickMainMenuButton()
    {      
        sceneController.GetComponent<SceneController>().MainMenuSceneProgression();
        gameHandler.GetComponent<GameHandler>().MoveToOriginalPosition();
    }

    public void OnClickPlayButton()
    {
        gameHandler.GetComponent<GameHandler>().isInMenu = false;
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        gameHandler.GetComponent<GameHandler>().doneCreating = true;       
        gameHandler.GetComponent<GameHandler>().CheckMenus();
        sceneController.GetComponent<SceneController>().CharacterSelectionSceneProgression();
        gameHandler.GetComponent<GameHandler>().MoveToFrame();
    }

    public void SwitchAttackButtonVisibility(bool isActive, bool isActive2)
    {
        if(attack1Button == null || attack2Button == null)
        {
            SetButtonsIfNull();
        }

        attack1Button.interactable = isActive;
        if(BattleController.instance.currentChar != null && BattleController.instance.currentChar.specialIsReady)
        {
            attack2Button.interactable = isActive2;
        }
        else
        {
            attack2Button.interactable = false;
        }
    }

    public void ChangeAttackButtonText()
    {
        if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Smash";
            attack1Button.GetComponent<Image>().sprite = buttonSprites[0];
            attack2Button.GetComponentInChildren<Text>().text = "Aggro";
            attack2Button.GetComponent<Image>().sprite = buttonSprites[9];
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
            attack1Button.GetComponent<Image>().sprite = buttonSprites[6];
            attack2Button.GetComponentInChildren<Text>().text = "Snipe";
            attack2Button.GetComponent<Image>().sprite = buttonSprites[7];
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Stab";
            attack1Button.GetComponent<Image>().sprite = buttonSprites[0];
            attack2Button.GetComponentInChildren<Text>().text = "Evasion";
            attack2Button.GetComponent<Image>().sprite = buttonSprites[8];
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
        {
            attack1Button.GetComponentInChildren<Text>().text = "Lightning Bolt";
            attack1Button.GetComponent<Image>().sprite = buttonSprites[10];
            attack2Button.GetComponentInChildren<Text>().text = "Fireball";
            attack2Button.GetComponent<Image>().sprite = buttonSprites[1];
        }

        if(!BattleController.instance.currentChar.specialIsReady)
        {
            attack2Button.GetComponentInChildren<Text>().text += ": " + BattleController.instance.currentChar.cooldown;
        }
    }

    private void SetButtonsIfNull()
    {
        attack1Button = GameObject.Find("attack1Button").GetComponent<Button>();
        attack2Button = GameObject.Find("attack2Button").GetComponent<Button>();
    }
}
