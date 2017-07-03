using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InfluenceSource
{
    public enum InfluenceType
    {
        Damage,
        Healing,
        CrowdControl,
        Buff,
        Debuff
    }
    public InfluenceType Type;

    /// <summary>
    /// Impact initilizer
    /// </summary>
    public IDestroyable Actor;
    public Effect Effect;
    public float RawHitpoints;
}
