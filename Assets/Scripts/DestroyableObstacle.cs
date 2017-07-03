using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DestroyableObstacle : IDestroyable
{
    protected int hitsToDestroy;
    public int HitsToDestroy
    {
        get
        {
            return hitsToDestroy;
        }
        set
        {
            if (value <= 0)
            {
                Destroy();
                return;
            }
            hitsToDestroy = value;
        }
    }
    public void Destroy()
    {
    }
}
