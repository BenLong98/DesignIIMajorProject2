using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlayerChar : MonoBehaviour
{
    private int _health;
    protected int _maxHealth;

    protected int _attack;
    protected int _defense;
    protected int _initiative;
    protected int _accuracy;

    public int health
    {
        get { return _health; }
        set { _health = value; }
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

	public void Hurt(int howHurt)
    {
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
