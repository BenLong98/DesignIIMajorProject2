using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGameHandler : MonoBehaviour {

    public GameObject sceneController;

	// Use this for initialization
	void Start () {
        sceneController = FindObjectOfType<SceneController>().gameObject;
    }

    public void BackToMainMenu() {
        sceneController.GetComponent<SceneController>().OnClickMainMenuButton();
    }

}
