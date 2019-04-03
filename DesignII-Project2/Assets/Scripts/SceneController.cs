using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance; //Singleton Pattern

    [SerializeField] string currentScene;
    [SerializeField] GameObject gameHandler;

    private void Awake()
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
    }

    void Start()
    {

    }

    public void CreditsSceneProgression()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void MainMenuSceneProgression()
    {

        SceneManager.LoadScene("MenuAfterCreation");
    }

    public void MainMenuSceneProgressionWin()
    {
        gameHandler.GetComponent<GameHandler>().level += 1;
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
        SceneManager.LoadScene("Battle");
    }

    public void CharacterSelectionSceneProgression()
    {
        SceneManager.LoadScene("Battle");
    }

}
