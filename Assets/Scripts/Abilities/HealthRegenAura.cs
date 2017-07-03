using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HealthRegenAura : Aura
{
    protected float regenPerSecond;
    public HealthRegenAura(Creature actor, Creature target, float regenPerSecond, int refreshFrequency = 1, float duration = -1F)
        : base(actor, target, refreshFrequency, duration)
    {
        this.regenPerSecond = regenPerSecond;
    }
    protected override void EffectBehaviour()
    {
        base.EffectBehaviour();
        AffectedCreature.RecoverHealth(regenPerSecond * timeToTick);
    }
}
