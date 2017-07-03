using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Effect : IEffect
{
    public float accumulator;
    public Effect(Creature performer, Creature target)
    {
        this.performer = performer;
        this.affectedCreature = target;
        accumulator = 0F;
    }
    protected Creature performer; // Effect Creator
    protected Creature affectedCreature; // Affected creature

    /// <summary>
    /// Effect performer
    /// </summary>
    public Creature Actor
    {
        get
        {
            return performer;
        }
    }

    /// <summary>
    /// Effect target
    /// </summary>
    public Creature AffectedCreature
    {
        get
        {
            return affectedCreature;
        }
    }

    /// <summary>
    /// Effect title
    /// </summary>
    public string Title;

    abstract public void Tick();

    public void Destroy()
    {
        AffectedCreature.RemoveEffect(this);
    }
    public void Remove()
    {
        Destroy();
    }
    public void AttachTo(Creature target)
    {
        AffectedCreature.Effects.Add(this);
    }

    protected virtual void EffectBehaviour()
    {
        //TODO: default effect behaviour
    }
}
