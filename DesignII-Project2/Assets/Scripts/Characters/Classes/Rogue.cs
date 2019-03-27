using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : GenericPlayerChar
{

    public Rogue()
    {
        _maxHealth = 50;

        _attack = 70;
        _defense = 80;
        _initiative = 90;
        _accuracy = 85;
        health = _maxHealth;
    }

    public void Stab(GenericEnemy enemyTohurt)
    {
        //To be implemented, probably when enemies are made
    }

    public void Evade()
    {
        //To be implemented, probably once we have the turn order sorted out
    }
}
