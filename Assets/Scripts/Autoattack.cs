using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Autoattack
{
    public float Damage
    {
        get
        {
            return damage;
        }
    }
    public float AttackSpeed
    {
        get
        {
            return attackSpeed;
        }
    }
    protected float damage;
    protected float attackSpeed;
}
