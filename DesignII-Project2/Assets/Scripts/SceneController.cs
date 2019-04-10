using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //public static SceneController instance; //Singleton Pattern

    public static string battleSceneName;

    [SerializeField] string currentScene;
    [SerializeField] GameObject gameHandler;

    public string publicCurrentScene
    {
        get { return currentScene; }
    }

    void Start()
    {
        if(gameHandler == null)
        {
            gameHandler = GameObject.Find("GameHandler");
        }
    }


    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickCreditsButton()
    {
        CreditsSceneProgression();
    }

    public void OnClickStartBattleButton()
    {
        gameHandler.GetComponent<GameHandler>().isInMenu = false;
        BattleSceneProgression();
    }

    public void OnClickPlayLevelButton()
    {
        gameHandler.GetComponent<GameHandler>().MoveToFrame();
        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        battleSceneName = "Battle";
        CharacterSelectionSceneProgression();
    }

    public void OnClickPlayLevelButton2()
    {
        gameHandler.GetComponent<GameHandler>().MoveToFrame();
        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        battleSceneName = "Battle2";
        CharacterSelectionSceneProgression();
    }

    public void OnClickPlayLevelButton3()
    {
        gameHandler.GetComponent<GameHandler>().MoveToFrame();
        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        battleSceneName = "Battle3";
        CharacterSelectionSceneProgression();
    }

    public void OnClickMainMenuButton()
    {
        MainMenuSceneProgression();
        gameHandler.GetComponent<GameHandler>().MoveToOriginalPosition();
    }

    public void OnClickPlayButton()
    {
        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        gameHandler.GetComponent<GameHandler>().doneCreating = true;
        gameHandler.GetComponent<GameHandler>().CheckMenus();


        CharacterSelectionSceneProgression();
       
    }



    public void CreditsSceneProgression()
    {
        SceneManager.LoadScene("CreditScreen");
    }


    public void MainMenuSceneProgressionWin()
    {
        if (gameHandler.GetComponent<GameHandler>().canGoTo[0] == true)
        {
            gameHandler.GetComponent<GameHandler>().canGoTo[1] = true;
            gameHandler.GetComponent<GameHandler>().level += 1;
        }
        else if (gameHandler.GetComponent<GameHandler>().canGoTo[1] == true)
        {
            gameHandler.GetComponent<GameHandler>().canGoTo[2] = true;
            gameHandler.GetComponent<GameHandler>().level += 1;
        }
        else if (gameHandler.GetComponent<GameHandler>().canGoTo[2]) {
            gameHandler.GetComponent<GameHandler>().canGoTo[2] = true;
            gameHandler.GetComponent<GameHandler>().level += 1;
        }

        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        gameHandler.GetComponent<GameHandler>().CheckMenus();


        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        gameHandler.GetComponent<GameHandler>().MoveToOriginalPosition();
        SceneManager.LoadScene("MenuAfterCreation");
    }

    public void MainMenuSceneProgression()
    {
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        gameHandler.GetComponent<GameHandler>().CheckMenus();

        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        gameHandler.GetComponent<GameHandler>().MoveToOriginalPosition();
        SceneManager.LoadScene("MenuAfterCreation");
    }

    public void HelpSceneProgression()
    {
        SceneManager.LoadScene("HelpScene");
    }  

    public void BattleSceneProgression()
    {
        SceneManager.LoadScene(battleSceneName);

    }

    public void CharacterSelectionSceneProgression()
    {
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        SceneManager.LoadScene("CharacterSelectionScene");
    }


    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
}
