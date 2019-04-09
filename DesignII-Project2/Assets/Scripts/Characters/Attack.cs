using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{

    private bool _isAttacking;
    private string _targetTag;
    private GameObject _target;

    [SerializeField] private AudioClip[] _attackSounds;
    [SerializeField] private AudioSource _attackSoundSource;

    public GameObject target
    {
        get { return _target;}
    }

    // Use this for initialization
    void Start()
    {
        _isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _target = hit.collider.gameObject;
                Debug.Log(_target.tag);
                AdjustButtonsForTarget();
            }
        }
    }

    public void OnAttackButtonClick()
    {
        AttackTarget(_target.GetComponent<GenericPlayerChar>());
    }

    public void OnSpecialAttackButtonClick()
    {
        SpecialAttackTarget();
    }

    private void AttackTarget(GenericPlayerChar targetOfAttack)
    {
        int chanceToMiss = Random.Range(0, 101);
        if (chanceToMiss < BattleController.instance.currentChar.accuracy)
        {
            Debug.Log("attack hit");
            if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian
                || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Knight
                || BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue)
            {
                int damage = (int)Mathf.Round(BattleController.instance.currentChar.attack * (1 -((float)targetOfAttack.defense / 100)));
                targetOfAttack.Hurt(damage);
                PlayAttackSound(_attackSounds[0]);
            }
            else if(BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Ranger)
            {
                int damage = (int)Mathf.Round(BattleController.instance.currentChar.attack * (1 - ((float)targetOfAttack.defense / 100)));
                targetOfAttack.Hurt(damage);
                PlayAttackSound(_attackSounds[2]);
            }
            else if(BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
            {
                int damage = (int)Mathf.Round(BattleController.instance.currentChar.attack * (1 - ((float)targetOfAttack.defense / 100)));
                targetOfAttack.Hurt(damage);
                PlayAttackSound(_attackSounds[3]);
            }
            else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Cleric)
            {
                targetOfAttack.Heal(targetOfAttack.maxHealth / 2);
                PlayAttackSound(_attackSounds[1]);
            }
        }

        BattleController.instance.NextTurn();
    }

    private void SpecialAttackTarget()
    {
        if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian)
        {
            BattleController.instance.currentChar.isAggro = true;
            //PlayAttackSound(_attackSounds[0]);
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Cleric)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject player in players)
            {
                GenericPlayerChar stats = player.GetComponent<GenericPlayerChar>();
                stats.Heal(stats.maxHealth / 3);
                PlayAttackSound(_attackSounds[1]);
            }
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Knight)
        {
            _target.GetComponent<GenericPlayerChar>().isShielded = true;
            //PlayAttackSound(_attackSounds[0]);
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Ranger)
        {
            int chanceToMiss = Random.Range(0, 101);
            if (chanceToMiss < BattleController.instance.currentChar.accuracy / 2)
            {
                int damage = (int)Mathf.Round(100 * (1 - ((float)_target.GetComponent<GenericPlayerChar>().defense / 100)));
                PlayAttackSound(_attackSounds[2]);
            }
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue)
        {
            BattleController.instance.currentChar.isEvading = true;
            //PlayAttackSound(_attackSounds[0]);
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                GenericPlayerChar stats = enemy.GetComponent<GenericPlayerChar>();
                int damage = (int)Mathf.Round(BattleController.instance.currentChar.attack * (1 - ((float)stats.defense / 100)) / 2);
                stats.Hurt(damage);
            }
            PlayAttackSound(_attackSounds[4]);
        }

        BattleController.instance.currentChar.SetCooldown();
        BattleController.instance.NextTurn();
    }

    private void AdjustButtonsForTarget()
    {
        if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Barbarian)
        {
            if(_target.tag == "Player")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, true);
            }
            else if( _target.tag == "Enemy")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(true, true);
            }
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Cleric)
        {
            if (_target.tag == "Player")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(true, true);
            }
            else if (_target.tag == "Enemy")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, true);
            }
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Knight)
        {
            if (_target.tag == "Player")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, true);
            }
            else if (_target.tag == "Enemy")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(true, false);
            }
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Ranger)
        {
            if (_target.tag == "Player")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, false);
            }
            else if (_target.tag == "Enemy")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(true, true);
            }
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Rogue)
        {
            if (_target.tag == "Player")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, true);
            }
            else if (_target.tag == "Enemy")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(true, true);
            }
        }
        else if (BattleController.instance.currentChar.classType == GenericPlayerChar.CharClass.Wizard)
        {
            if (_target.tag == "Player")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(false, true);
            }
            else if (_target.tag == "Enemy")
            {
                GameObject.Find("UIController").GetComponent<UIController>().SwitchAttackButtonVisibility(true, true);
            }
        }
        GameObject.Find("UIController").GetComponent<UIController>().ChangeAttackButtonText();
    }

    private void PlayAttackSound(AudioClip sound)
    {
        _attackSoundSource.clip = sound;
        _attackSoundSource.Play();
    }
}