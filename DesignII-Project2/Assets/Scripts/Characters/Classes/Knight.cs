using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : GenericPlayerChar
{

	public Knight()
    {
        _maxHealth = 75;

        _attack = 80;
        _defense = 90;
        _initiative = 55;
        _accuracy = 75;
        health = _maxHealth;
    }

    public void Slash(GenericEnemy enemyTohurt)
    {
        //To be implemented, probably when enemies are made
    }

    public void Shield(GenericPlayerChar charToShield)
    {
        //To be implemented, probably once we have the turn order sorted out
    }
}
