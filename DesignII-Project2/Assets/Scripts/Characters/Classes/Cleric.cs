using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : GenericPlayerChar
{
    public Cleric()
    {
        _maxHealth = 70;

        _attack = 0;
        _defense = 75;
        _initiative = 70;
        _accuracy = 100;
        health = _maxHealth;
    }

    public void HealOne(GenericPlayerChar charToHeal)
    {
        int healAmount = charToHeal.maxHealth / 2;
        charToHeal.Heal(healAmount);
    }

    public void HealAll(GenericPlayerChar[] charsToHeal)
    {
        foreach(GenericPlayerChar character in charsToHeal)
        {
            int healAmount = character.maxHealth / 3;
            character.Heal(healAmount);
        }
    }
}
