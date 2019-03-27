using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : GenericPlayerChar
{

    public Barbarian()
    {
        _maxHealth = 90;

        _attack = 90;
        _defense = 50;
        _initiative = 70;
        _accuracy = 75;
        health = _maxHealth;
    }

    public void Smash(GenericEnemy enemyTohurt)
    {
        //To be implemented, probably when enemies are made
    }

    public void Aggro()
    {
        //To be implemented, probably once we have the turn order sorted out
    }
}
