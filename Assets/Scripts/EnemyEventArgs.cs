using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EnemyEventArgs : EventArgs
{
    public IDestroyable Enemy
    {
        get
        {
            return Source.Actor;
        }
        set
        {
            Source.Actor = value;
        }
    }
    public float RawHitpoints
    {
        get
        {
            return Source.RawHitpoints;
        }
        set
        {
            Source.RawHitpoints = value;
        }
    }
    public InfluenceSource Source
    {
        get
        {
            if (source == null)
            {
                source = new InfluenceSource();
            }
            return source;
        }
        set
        {
            source = value;
        }
    }
    protected InfluenceSource source;
}
