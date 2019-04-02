using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    public static BattleController instance;

    private List<GenericPlayerChar> _allUnits = new List<GenericPlayerChar>();
    private GenericPlayerChar _currentChar;

    public GenericPlayerChar currentChar
    {
        get { return _currentChar; }
    }

	// Use this for initialization
	void Start () {
        instance = this;

        GameObject.Find("UIController").GetComponent<UIController>().SwitchAttachButtonVisibility(false);

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

        NextTurn();
    }

    void SortByInitiative()
    {
        _allUnits.Sort(delegate (GenericPlayerChar a, GenericPlayerChar b)
        {
            return (b.initivative.CompareTo(a.initivative));
        });
    }

    public void NextTurn()
    {
        _currentChar = _allUnits[0];
        _allUnits.Remove(_currentChar);

        if (_currentChar.health > 0)
        {
            _allUnits.Add(_currentChar);

            if(_currentChar.tag == "Player")
            {
                Debug.Log("Player turn: " + _currentChar.classType);
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttachButtonVisibility(true);
                GameObject.Find("UIController").GetComponent<UIController>().ChangeAttackButtonText();
            }
            else
            {
                Debug.Log("Enemy turn");
                int chanceToMiss = Random.Range(0, 101);
                if (chanceToMiss < BattleController.instance.currentChar.accuracy)
                {
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                    int target = Random.Range(0, players.Length - 1);
                    players[target].GetComponent<GenericPlayerChar>().Hurt((currentChar.attack) - (players[target].GetComponent<GenericPlayerChar>().defense));
                }
                NextTurn();
            }
        }
        else
        {
            NextTurn();
        }
    }
}
