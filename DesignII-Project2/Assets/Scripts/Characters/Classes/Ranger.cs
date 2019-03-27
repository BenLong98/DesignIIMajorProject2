using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : GenericPlayerChar
{
    public Ranger()
    {
        _maxHealth = 65;

        _attack = 75;
        _defense = 70;
        _initiative = 80;
        _accuracy = 95;
        health = _maxHealth;
    }

    public void Arrow(GenericEnemy enemyTohurt)
    {
        //To be implemented, probably when enemies are made
    }

    public void Snipe(GenericEnemy enemyToHurt)
    {
        //To be implemented, probably when enemies are made
    }
}
