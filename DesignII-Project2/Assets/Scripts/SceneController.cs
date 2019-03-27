using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance; //Singleton Pattern

    [SerializeField] string currentScene;

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
        SceneManager.LoadScene("MainMenuScene");
    }

    public void HelpSceneProgression()
    {
        SceneManager.LoadScene("HelpScene");
    }

}
