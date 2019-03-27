using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {

    private List<GenericPlayerChar> _chars = new List<GenericPlayerChar>();
    private List<GenericEnemy> _enemies = new List<GenericEnemy>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SortByInitiative()
    {
        List<GameObject> battlers = new List<GameObject>();
        foreach(GenericPlayerChar chara in _chars)
        {
            battlers.Add(chara.gameObject);
        }
        foreach(GenericEnemy enemy in _enemies)
        {
            battlers.Add(enemy.gameObject);
        }

        //Sort by initiative
    }
}
