using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EffectOverTime : Effect
{
    protected float timeToTick;
    protected int ticks;
    public int TicksRemain
    {
        get
        {
            return ticks;
        }
        set
        {
            ticks = value;
            if (value == 0)
            {
                Destroy();
            }
        }
    }
    public EffectOverTime(Creature actor, Creature target, float timeToTick, int ticks)
        : base(actor, target)
    {
        this.timeToTick = timeToTick;
        this.ticks = ticks;
    }
    public override void Tick()
    {
        accumulator += Time.deltaTime;
        if (accumulator >= timeToTick)
        {
            EffectBehaviour();
            TicksRemain--;
            accumulator -= timeToTick;
        }
    }
}
