using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {

    private List<GenericPlayerChar> _allUnits = new List<GenericPlayerChar>();

	// Use this for initialization
	void Start () {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject unit in players)
        {
            _allUnits.Add(unit.GetComponent<GenericPlayerChar>());
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject unit in enemies)
        {
            _allUnits.Add(unit.GetComponent<GenericPlayerChar>());
        }

        SortByInitiative();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SortByInitiative()
    {
        Debug.Log("unsort");
        foreach(GenericPlayerChar a in _allUnits)
        {
            Debug.Log(a.initivative);
        }

        _allUnits.Sort(delegate (GenericPlayerChar a, GenericPlayerChar b)
        {
            return (b.initivative.CompareTo(a.initivative));
        });

        Debug.Log("sort");
        foreach (GenericPlayerChar a in _allUnits)
        {
            Debug.Log(a.initivative);
        }
    }
}
