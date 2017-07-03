using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Healing : EffectOverTime
{
    float healingPerTick;
    public Healing(Creature actor, Creature target, float healingPerTick, float timeToTick, int ticks)
        : base(actor, target, timeToTick, ticks)
    {
        this.healingPerTick = healingPerTick;

        Debug.Log(actor.Name + " heals " + target.Name);
    }
    protected override void EffectBehaviour()
    {
        base.EffectBehaviour();
        AffectedCreature.TakeHealing(this, healingPerTick);
    }
}
