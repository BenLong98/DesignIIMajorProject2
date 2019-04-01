using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("MainMenuExclusiveUI")]
    public Button gearButton;
    public GameObject gearPanel;

    [Header("CharacterSelectionExclusiveUI")]
    public Button startBattleButton;
    public Button mainMenuButton;

    [Header("UniversalUI")]
    public Button quitButton;

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

}
