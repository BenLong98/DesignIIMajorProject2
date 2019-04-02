using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {

    private bool _isAttacking;
    private string _targetTag;

	// Use this for initialization
	void Start () {
        _isAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_isAttacking) return;       

        //Turn off the halo
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == _targetTag)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    AttackTarget(hit.collider.gameObject.GetComponent<GenericPlayerChar>());
                }

                //Do work with turning on the halo
            }
        }   
	}

    public void OnAttackButtonClick()
    {
        _isAttacking = true;
        GameObject.Find("UIController").GetComponent<UIController>().SwitchAttachButtonVisibility(false);

        if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian
            || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Knight
            || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Ranger
            || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue
            || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
        {
            _targetTag = "Enemy";
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Cleric)
        {
            _targetTag = "Player";
        }

        Debug.Log("Player attacking...");
    }

    private void AttackTarget(GenericPlayerChar target)
    {
        int chanceToMiss = Random.Range(0, 101);
        if (chanceToMiss < BattleController.instance.currentChar.accuracy)
        {
            if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian
                || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Knight
                || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Ranger
                || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue
                || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
            {
                target.Hurt((BattleController.instance.currentChar.attack) - (target.defense));
            }
            else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Cleric)
            {
                target.Heal(target.maxHealth / 2);
            }
        }

        BattleController.instance.NextTurn();
    }
}
