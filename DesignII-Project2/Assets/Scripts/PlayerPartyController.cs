using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyController : MonoBehaviour {

    public static PlayerPartyController instance;

	// Use this for initialization
	void Start () {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        
        //uncomment this out if you're done testing
        //gameObject.SetActive(false);
	}
	
	public void StartBattle()
    {
        gameObject.SetActive(true);
    }

    public void EndBattle()
    {
        gameObject.SetActive(false);
    }
}
