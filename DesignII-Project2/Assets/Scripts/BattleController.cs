using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    public static BattleController instance;

    [SerializeField]
    private Button _attackButton;
    private List<GenericPlayerChar> _allUnits = new List<GenericPlayerChar>();
    private GenericPlayerChar _currentChar;

    public GenericPlayerChar currentChar
    {
        get { return _currentChar; }
    }

	// Use this for initialization
	void Start () {
        instance = this;

        _attackButton.gameObject.SetActive(false);

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

    public void NextTurn()
    {
        _currentChar = _allUnits[0];
        _allUnits.Remove(_currentChar);

        if(_currentChar.health > 0)
        {
            _allUnits.Add(_currentChar);

            if(_currentChar.tag == "Player")
            {
                Debug.Log("Player turn");
                _attackButton.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Enemy turn");
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                int target = Random.Range(0, players.Length - 1);
                players[target].GetComponent<GenericPlayerChar>().Hurt((currentChar.attack) - (players[target].GetComponent<GenericPlayerChar>().defense));
                NextTurn();
            }
        }
        else
        {
            NextTurn();
        }
    }
}
