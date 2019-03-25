using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : GenericPlayerChar
{

	public Knight()
    {
        _maxHealth = 80;

        _attack = 80;
        _defense = 90;
        _initiative = 50;
        _accuracy = 75;
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
