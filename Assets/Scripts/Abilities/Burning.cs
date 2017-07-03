using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Burning : EffectOverTime
{
    float damagePerTick;
    public Burning(Creature actor, Creature target, float damagePerTick, float timeToTick, int ticks)
        : base(actor, target, timeToTick, ticks)
    {
        this.damagePerTick = damagePerTick;

        Debug.Log(actor.Name + " burns " + target.Name);
    }
    protected override void EffectBehaviour()
    {
        base.EffectBehaviour();
        AffectedCreature.TakeDamage(this, damagePerTick);
    }
}
