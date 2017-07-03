using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Aura : Effect
{
    /// <summary>
    /// Minimal tick frequence = 10 Hz
    /// </summary>
    public const float MIN_TICK_TIME = .1f;
    public bool IsEndless
    {
        get
        {
            return isEndless;
        }
    }
    /// <summary>
    /// Aura voids when time expires
    /// </summary>
    public float RemainingTime
    {
        get
        {
            return remainingTime;
        }
        set
        {
            if (value <= 0)
            {
                Destroy();
                return;
            }
            remainingTime = value;
        }
    }
    protected bool isEndless;
    protected float remainingTime;
    protected float timeToTick;
    /// <summary>
    /// Creates an aura effect
    /// </summary>
    /// <param name="actor">Creator (root source) of effect</param>
    /// <param name="target">Effect target</param>
    /// <param name="refreshFrequency">Ticks frequency (Hertz)</param>
    /// <param name="duration">Duration in seconds (-1 for endless)</param>
    public Aura(Creature actor, Creature target, int refreshFrequency = 1, float duration = -1F) : base(actor, target)
    {
        isEndless = duration == -1;
        timeToTick = Mathf.Max(1 / refreshFrequency, MIN_TICK_TIME);
    }
    /// <summary>
    /// Creates an aura effect
    /// </summary>
    /// <param name="actor">Creator (root source) of effect</param>
    /// <param name="target">Effect target</param>
    /// <param name="timeToTick">Ticks frequency (seconds)</param>
    /// <param name="duration">Duration in seconds (-1 for endless)</param>
    public Aura(Creature actor, Creature target, float timeToTick = 1, float duration = -1F) : base(actor, target)
    {
        isEndless = duration == -1;
        this.timeToTick = Mathf.Max(timeToTick, MIN_TICK_TIME);
    }

    public override void Tick()
    {
        accumulator += Time.deltaTime;
        if (accumulator > timeToTick)
        {
            if (!IsEndless)
            {
                RemainingTime -= Time.deltaTime;
            }
            EffectBehaviour();
            accumulator -= timeToTick;
        }
    }
}
