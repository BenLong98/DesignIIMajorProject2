using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : GenericPlayerChar
{
    public Wizard()
    {
        _maxHealth = 70;

        _attack = 75;
        _defense = 70;
        _initiative = 75;
        _accuracy = 85;
        health = _maxHealth;
    }

    public void LightningBolt(GenericEnemy enemyTohurt)
    {
        //To be implemented, probably when enemies are made
    }

    public void Fireball (GenericEnemy[] enemiesToHurt)
    {
        //To be implemented, probably when enemies are made
    }
}
