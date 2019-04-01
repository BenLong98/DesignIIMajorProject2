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

}
