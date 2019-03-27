using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Button gearButton;
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

}
