using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayerChar : MonoBehaviour
{
    private int _health;
    [SerializeField] private int _maxHealth;

    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _initiative;
    [SerializeField] private int _accuracy;

    [SerializeField] private CharClass _classType;

    private int _originalDefense;

    private bool _isShielded;
    private bool _isEvading;
    private bool _isAggro;

    public enum CharClass
    {
        Barbarian,
        Cleric,
        Knight,
        Ranger,
        Rogue,
        Wizard,
        Goblin,
        Orc,
        Sorcerer
    }

    public CharClass classType
    {
        get { return _classType; }
    }

    public int health
    {
        get { return _health; }
    }

    public int attack
    {
        get { return _attack; }
    }

    public int defense
    {
        get { return _defense; }
    }

    public int initivative
    {
        get { return _initiative; }
    }

    public int accuracy
    {
        get { return _accuracy; }
    }

    public int maxHealth
    {
        get { return _maxHealth; }
    }

    public bool isShielded
    {
        get { return _isShielded; }
        set { _isShielded = value; }
    }

    public bool isEvading
    {
        get { return _isEvading; }
        set { _isEvading = value; }
    }

    public bool isAggro
    {
        get { return _isAggro; }
        set { _isAggro = value; }
    }

    private void Start()
    {
        _health = _maxHealth;
        _originalDefense = _defense;
    }

    private void OnEnable()
    {
        _health = _maxHealth;
        _originalDefense = _defense;
    }

    private void Update()
    {
        if(_isEvading)
        {
            _defense = 100;
        }
        else if(_isShielded)
        {
            _defense = 90;
        }
        else
        {
            _defense = _originalDefense;
        }
    }

    public void Hurt(int howHurt)
    {
        if (howHurt < 0)
            howHurt = 0;
        _health -= howHurt;
    }

    public void Heal(int howHeal)
    {
        _health += howHeal;

        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}
