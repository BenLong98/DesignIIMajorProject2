using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {

    [SerializeField]
    private Button _attackButton;
    private bool _isAttacking;

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
            if (hit.collider.gameObject.tag == "Enemy")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Excuse the formatting, I'm lazy
                    hit.collider.gameObject.GetComponent<GenericPlayerChar>().Hurt((BattleController.instance.currentChar.attack) - (hit.collider.GetComponent<GenericPlayerChar>().defense));
                    BattleController.instance.NextTurn();
                }

                //Do work with turning on the halo
            }
        }   
	}

    public void OnAttackButtonClick()
    {
        _isAttacking = true;
        _attackButton.gameObject.SetActive(false);
        Debug.Log("Player attacking...");
    }
}
