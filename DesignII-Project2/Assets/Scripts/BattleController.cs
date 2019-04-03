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

        GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, false);

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
        CheckIfBattleEnded();

        _currentChar = _allUnits[0];
        _allUnits.Remove(_currentChar);

        if (_currentChar.health > 0)
        {
            _allUnits.Add(_currentChar);

            if(_currentChar.tag == "Player")
            {
                Debug.Log("Player turn: " + _currentChar.classType);

                //Upkeep for classes with lasting buffs.
                if (currentChar.classType == GenericPlayerChar.CharClass.Barbarian)
                {
                    currentChar.isAggro = false;
                }
                if (currentChar.classType == GenericPlayerChar.CharClass.Knight)
                {
                    foreach(GenericPlayerChar chara in _allUnits)
                    {
                        chara.isShielded = false;
                    }
                }
                if(currentChar.classType == GenericPlayerChar.CharClass.Rogue)
                {
                    currentChar.isEvading = false;
                }

                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(true, true);
                GameObject.Find("UIController").GetComponent<UIController>().ChangeAttackButtonText();
                CharacterInfoAndIconUIElement.iconName = currentChar.classType.ToString();
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, false);

                if(currentChar.classType == GenericPlayerChar.CharClass.Barbarian
                || currentChar.classType == GenericPlayerChar.CharClass.Cleric
                || currentChar.classType == GenericPlayerChar.CharClass.Rogue
                || currentChar.classType == GenericPlayerChar.CharClass.Wizard)
                {
                    GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, true);
                }
            }
            else
            {
                Debug.Log("Enemy turn");
                int chanceToMiss = Random.Range(0, 101);
                if (chanceToMiss < currentChar.accuracy)
                {
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                    int target = -1;
                    //Scans for aggroed players and targets them. If no aggroed players, just target a random one.
                    for(int i = 0; i < 3; i++)
                    {
                        if(players[i].GetComponent<GenericPlayerChar>().isAggro)
                        {
                            target = i;
                        }
                    }
                    if (target == -1)
                    {
                        target = Random.Range(0, players.Length - 1);
                    }

                    int damage = (int)Mathf.Round(currentChar.attack * (1 - ((float)players[target].GetComponent<GenericPlayerChar>().defense / 100)));
                    players[target].GetComponent<GenericPlayerChar>().Hurt(damage);
                }
                NextTurn();
            }
        }
        else
        {
            NextTurn();
        }
    }

    private void CheckIfBattleEnded()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        bool playersAlive = false;
        bool enemiesAlive = false;

        foreach(GameObject player in players)
        {
            if(player.GetComponent<GenericPlayerChar>().health > 0)
            {
                playersAlive = true;
            }
        }

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<GenericPlayerChar>().health > 0)
            {
                enemiesAlive = true;
            }
        }

        if(!playersAlive || !enemiesAlive)
        {
            Invoke("BackToMenu", 2);
        }
    }

    private void BackToMenu()
    {
        SceneController.instance.MainMenuSceneProgressionWin();
        PlayerPartyController.instance.EndBattle();
    }
}
