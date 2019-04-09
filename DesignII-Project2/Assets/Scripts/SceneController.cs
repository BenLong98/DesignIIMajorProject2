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

    private void Awake()
    {
    }

    void Start()
    {

    }

    public void CreditsSceneProgression()
    {
        SceneManager.LoadScene("CreditScreen");
    }

   // public void MainMenuSceneProgression()
  //  {
//
       // SceneManager.LoadScene("MenuAfterCreation");
 //   }

    public void MainMenuSceneProgressionWin()
    {
        gameHandler.GetComponent<GameHandler>().level += 1;
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        gameHandler.GetComponent<GameHandler>().CheckMenus();
        //gameHandler.GetComponent<GameHandler>().uiController.SetActive(true);
        //gameHandler.GetComponent<GameHandler>().gearMain.SetActive(true);
        //gameHandler.GetComponent<GameHandler>().uiController.SetActive(true);
        //gameHandler.GetComponent<GameHandler>().uiController.SetActive(true);

        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        SceneManager.LoadScene("MenuAfterCreation");
    }

    public void MainMenuSceneProgression()
    {
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        gameHandler.GetComponent<GameHandler>().CheckMenus();

        gameHandler.GetComponent<GameHandler>().isInMenu = true;
        SceneManager.LoadScene("MenuAfterCreation");
    }

    public void HelpSceneProgression()
    {
        SceneManager.LoadScene("HelpScene");
    }  

    public void BattleSceneProgression()
    {
        //gameHandler.GetComponent<GameHandler>().uiController.SetActive(false);
        SceneManager.LoadScene(battleSceneName);

    }

    public void CharacterSelectionSceneProgression()
    {
       // gameHandler.GetComponent<GameHandler>().uiController.SetActive(false);
        gameHandler.GetComponent<GameHandler>().isInMenu = false;
        gameHandler.GetComponent<GameHandler>().menuCounter += 1;
        //PlayerCanvasController.instance.playerCanvas.SetActive(false);
        //PlayerPartyController.instance.playerCanvas.SetActive(false);
        SceneManager.LoadScene("CharacterSelectionScene");
    }


    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
}
